using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/customers/{userId}/weeklyorder")]
    [ApiController]
    [RequireLogin(RoleType.Person, RoleType.CustomerBusiness)]
    public class WeeklyOrdersController : ControllerBase
    {
        private readonly IWeeklyOrdersService weeklyOrdersService;

        public WeeklyOrdersController(IWeeklyOrdersService weeklyOrdersService)
        {
            this.weeklyOrdersService = weeklyOrdersService;
        }

        [HttpPost("subscription")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> Subscribe([FromRoute] int userId, [FromBody] DeliveryInfoInputDto deliveryInfo)
        {
            return Ok(await this.weeklyOrdersService.Subscribe(userId, deliveryInfo));
        }

        [HttpDelete("subscription")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> Unsubscribe([FromRoute] int userId)
        {
            await this.weeklyOrdersService.Unsubscribe(userId);
            return NoContent();
        }

        [HttpGet]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> GetWeeklyOrderData([FromRoute] int userId)
        {
            return Ok(await this.weeklyOrdersService.GetWeeklyOrderData(userId));
        }
    }
}