﻿using GreenProject.Backend.Contracts.Reports;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Entities.Utils;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class ReportsService : AbstractService, IReportsService
    {
        private const decimal KILOGRAMS_PER_SLOT = 0.5m;
        private readonly PricingSettings pricingSettings;

        public ReportsService(IRequestSession request, PricingSettings pricingSettings)
            : base(request)
        {
            this.pricingSettings = pricingSettings;
        }

        public async Task<IEnumerable<OrderReportModel>> GetDailyOrdersReport(DateTime date)
        {
            return await this.Data
                .Orders
                .Where(o => o.DeliveryDate == date)
                .Where(o => o.OrderState != OrderState.Canceled)
                .Select(o => new OrderReportModel
                {
                    OrderNumber = o.OrderNumber,
                    Street = o.Address.Street,
                    HouseNumber = o.Address.HouseNumber,
                    City = o.Address.Zone.City,
                    ZipCode = o.Address.ZipCode,
                    Name = o.Address.Name
                })
                .ToArrayAsync();
        }

        public async Task<IEnumerable<ProductReportModel>> GetDailyRequestedProductsReport(DateTime date)
        {
           IEnumerable<Order> orders = await this.Data
                .Orders
                .Where(o => o.OrderState != OrderState.Canceled)
                .Where(o => o.DeliveryDate == date)
                .Include(o => o.Details)
                    .ThenInclude(d => d.Item)
                .Include(o => o.Details)
                    .ThenInclude(d => d.SubProducts)
                        .ThenInclude(s => s.Product)
                .OrderByDescending(o => o.IsSubscription)
                .ToArrayAsync();

            IEnumerable<ProductReportModel> models = orders.SelectMany(this.CreateOrderSections);

            return models;
        }

        private IEnumerable<ProductReportModel> CreateOrderSections(Order order)
        {
            IList<ProductReportModel> records = order
                .Details
                .Where(d => d.Item is Crate)
                .Select((detail, i) => new ProductReportModel
                {
                    OrderNumber = $"{order.OrderNumber} ({i + 1})",
                    ProductQuantities = detail
                        .SubProducts
                        .ToDictionary(s => this.GetProductHeaderString(s.Product), this.GetActualCrateQuantityInMainUnit),
                    Weight = (detail.Item as Crate).Capacity * KILOGRAMS_PER_SLOT
                })
                .ToList();

            if (order.Details.Any(d => d.Item is Product))
            {
                records.Add(new ProductReportModel
                {
                    OrderNumber = $"{order.OrderNumber} (F)",
                    ProductQuantities = order
                        .Details
                        .Where(d => d.Item is Product)
                        .ToDictionary(d => this.GetProductHeaderString(d.Item as Product), this.GetActualDetailQuantityInMainUnit),
                    Weight = null
                });
            }

            return records;
        }

        private string GetProductHeaderString(Product product)
        {
            return $"{product.Name} ({product.UnitName.GetPrintableName()})";
        }

        private decimal GetActualDetailQuantityInMainUnit(OrderDetail detail)
        {
            return detail.Quantity * (detail.Item as Product).UnitMultiplier;
        }

        private decimal GetActualCrateQuantityInMainUnit(OrderDetailSubProduct subProduct)
        {
            return subProduct.Product.UnitName switch
            {
                UnitName.Kilogram => subProduct.Quantity * subProduct.Product.CrateMultiplier * KILOGRAMS_PER_SLOT,
                UnitName.Piece => subProduct.Quantity,
                _ => throw new FormatException("Unrecognized unit name")
            };
        }

        public async Task<IEnumerable<SupplierProductReportModel>> GetDailySupplierReport(DateTime date, IEnumerable<int> categories)
        {
            var products = await this.Data
                .Products
                .Where(p => !p.IsDeleted)
                .Where(p => categories.Contains(p.CategoryId))
                .Select(p => new
                {
                    Product = p,
                    CrateQuantity = p
                        .SubProducts
                        .Where(s => s.OrderDetail.Order.DeliveryDate == date)
                        .Where(o => o.OrderDetail.Order.OrderState != OrderState.Canceled)
                        .Sum(s => s.Quantity),
                    OrderDetailQuantity = p
                        .OrderDetails
                        .Where(o => o.Order.DeliveryDate == date)
                        .Where(o => o.Order.OrderState != OrderState.Canceled)
                        .Sum(s => s.Quantity),
                })
                .ToArrayAsync();

            return products
                .Select(p => new SupplierProductReportModel
                {
                    ProductName = p.Product.Name,
                    UnitName = p.Product.UnitName.GetPrintableName(),
                    Quantity = p.OrderDetailQuantity * p.Product.UnitMultiplier + p.CrateQuantity
                });
        }

        public async Task<IEnumerable<DailyRevenueModel>> GetRevenueReport(DateTime date)
        {
            IEnumerable<Order> orders = await this.Data
                .Orders
                .Where(o => o.OrderState == OrderState.Completed)
                .Where(o => o.DeliveryDate.Year == date.Year && o.DeliveryDate.Month == date.Month)
                .Include(o => o.Details)
                    .ThenInclude(d => d.Item)
                .ToArrayAsync();

            DateTime startOfMonth = new DateTime(date.Year, date.Month, 1);

            return EnumerableUtils.EnumerateDates(startOfMonth)
                .Take(System.DateTime.DaysInMonth(date.Year, date.Month))
                .GroupJoin(orders, d => d, o => o.DeliveryDate, this.CreateDailyRevenueModel);
        }

        private DailyRevenueModel CreateDailyRevenueModel(DateTime date, IEnumerable<Order> orders)
        {
            DailyRevenueModel record = new DailyRevenueModel { Date = date };

            orders
                .Peek(o => record.IvaValues.Merge(this.pricingSettings.ShippingIvaPercentage, o.ShippingCost, (a, b) => a + b))
                .SelectMany(o => o.Details)
                .ForEach(d =>
                {
                    Money increment = d.Price * d.Quantity * (1 + d.Item.IvaPercentage);
                    record.IvaValues.Merge(d.Item.IvaPercentage, increment, (a, b) => a + b);
                });

            return record;
        }
    }
}
