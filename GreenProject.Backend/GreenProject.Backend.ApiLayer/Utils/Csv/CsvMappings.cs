using CsvHelper.Configuration;
using GreenProject.Backend.Contracts.Reports;
using GreenProject.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Utils.Csv
{
    public static class CsvMappings
    {
        public abstract class OrderedClassMap<T> : ClassMap<T>
        {
            private readonly CsvReportSettings settings;

            public OrderedClassMap(CsvReportSettings settings)
            {
                this.settings = settings;
            }

            public MemberMap<T, TProperty> AddPropertyMap<TProperty>(Expression<Func<T, TProperty>> property)
            {
                return Map(property).Name(this.settings.HeaderNames[this.GetPropertyName(property)]);
            }

            private string GetPropertyName<TProperty>(Expression<Func<T, TProperty>> property)
            {
                MemberExpression memberExpression;

                if (property.Body is UnaryExpression)
                {
                    UnaryExpression unaryExpression = (UnaryExpression)property.Body;
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                }
                else
                {
                    memberExpression = (MemberExpression)property.Body;
                }

                return ((PropertyInfo)memberExpression.Member).Name;
            }
        }

        public class OrderReportModelMap : OrderedClassMap<OrderReportModel>
        {
            public OrderReportModelMap(CsvReportSettings settings)
                : base(settings)
            {
                AddPropertyMap(x => x.Street);
                AddPropertyMap(x => x.HouseNumber);
                AddPropertyMap(x => x.City);
                AddPropertyMap(x => x.ZipCode);
                AddPropertyMap(x => x.Name);
                AddPropertyMap(x => x.OrderNumber);
            }
        }

        public class SupplierProductReportModelMap : OrderedClassMap<SupplierProductReportModel>
        {
            public SupplierProductReportModelMap(CsvReportSettings settings)
                : base(settings)
            {
                AddPropertyMap(x => x.ProductName);
                AddPropertyMap(x => x.Quantity);
                AddPropertyMap(x => x.UnitName);
            }
        }

        public class ProductReportModelMap : OrderedClassMap<ProductReportModel>
        {
            public ProductReportModelMap(CsvReportSettings settings, IEnumerable<string> productNames, IFormatProvider quantityFormat)
                : base(settings)
            {
                AddPropertyMap(x => x.OrderNumber);
                productNames.ForEach(n => Map()
                    .Name(n)
                    .ConvertUsing((object r) => GetQuantityForProduct(r, n, quantityFormat)));
                AddPropertyMap(x => x.Weight);
            }

            private string GetQuantityForProduct(object productItem, string productName, IFormatProvider quantityFormat)
            {
                return ((ProductReportModel)productItem)
                    .ProductQuantities
                    .GetValueAsOptional(productName)
                    .Map(d => d.ToString(quantityFormat))
                    .OrElse(string.Empty);
            }
        }

        public class DailyRevenueModelMap : OrderedClassMap<DailyRevenueModel>
        {
            private const string KEY_FORMAT = "Total{0}Percent";
            
            public DailyRevenueModelMap(CsvReportSettings settings, IEnumerable<int> ivaValues, IFormatProvider valueFormat)
                : base(settings)
            {
                AddPropertyMap(x => x.Date);
                ivaValues.ForEach(iva =>
                {
                    Map()
                        .Name(settings.HeaderNames[string.Format(KEY_FORMAT, iva)])
                        .ConvertUsing(r => ((DailyRevenueModel)r).IvaValues.GetValueAsOptional(iva / 100m).OrElse(0).ToString(valueFormat));
                });
                
            }
        }
    }
}
