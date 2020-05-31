using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet("customers/{customerId}/orders")]
        [RequireLogin(RoleType.Administrator, RoleType.Person)]
        [OwnerOrAdminOnly(PropertyName = "customerId")]
        public async Task<IActionResult> GetCustomerOrders([FromRoute] int customerId, [FromQuery] OrderFilters filters, [FromQuery] PaginationFilter pagination)
        {
            return Ok(await _ordersService.GetCustomerOrders(customerId, filters, pagination));
        }

        [HttpGet("orders")]
        [RequireLogin(RoleType.Administrator, RoleType.DeliveryMan)]
        public async Task<IActionResult> GetSupplierOrders([FromQuery] OrderFilters filters, [FromQuery] PaginationFilter pagination)
        {
            return Ok(await _ordersService.GetSupplierOrders(filters, pagination));
        }

        [HttpPut("orders/{orderId}/state")]
        [RequireLogin(RoleType.Administrator, RoleType.DeliveryMan)]
        public async Task<IActionResult> ChangeOrderState([FromRoute] int orderId, [FromBody] ChangeOrderStateDto request)
        {
            await _ordersService.ChangeOrderState(orderId, request);
            return NoContent();
        }
    }
}