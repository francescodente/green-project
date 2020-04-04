using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Orders.States;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
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

        [HttpGet("orders")]
        [RequireLogin(RoleType.Administrator, RoleType.DeliveryMan)]
        public async Task<IActionResult> GetSupplierOrders([FromQuery] OrderFilters filters, [FromQuery] PaginationFilter pagination)
        {
            return Ok(await this.ordersService.GetSupplierOrders(filters, pagination));
        }

        [HttpPut("orders/{orderId}/state")]
        [RequireLogin(RoleType.Administrator, RoleType.DeliveryMan)]
        public async Task<IActionResult> ChangeOrderState([FromRoute] int orderId, [FromBody] OrderStateDto newState)
        {
            await this.ordersService.ChangeOrderState(orderId, newState);
            return NoContent();
        }
    }
}