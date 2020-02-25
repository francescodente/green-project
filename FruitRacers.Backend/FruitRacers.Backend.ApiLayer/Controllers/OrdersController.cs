using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.ApiLayer.Routes;
using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE)]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpGet("customers/{customerId}/orders")]
        [RequireLogin(RoleType.CustomerBusiness, RoleType.Person, RoleType.Administrator)]
        [OwnerOrAdminOnly(PropertyName = "customerId")]
        public async Task<IActionResult> GetCustomerOrders([FromRoute] int customerId, [FromQuery] OrderFilters filters, [FromQuery] PaginationFilter pagination)
        {
            return Ok(await this.ordersService.GetCustomerOrders(customerId, filters, pagination));
        }

        [HttpGet("suppliers/{supplierId}/orders")]
        [RequireLogin(RoleType.Supplier, RoleType.Administrator)]
        [OwnerOrAdminOnly(PropertyName = "supplierId")]
        public async Task<IActionResult> GetSupplierOrders([FromRoute] int supplierId, [FromQuery] OrderFilters filters, [FromQuery] PaginationFilter pagination)
        {
            return Ok(await this.ordersService.GetSupplierOrders(supplierId, filters, pagination));
        }
    }
}