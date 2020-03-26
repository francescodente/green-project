using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.TimeSlots;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/timeslots")]
    [ApiController]
    public class TimeSlotsController : ControllerBase
    {
        private const int DEFAULT_DAYS_COUNT = 3;
        private readonly ITimeSlotsService timeSlotsService;

        public TimeSlotsController(ITimeSlotsService timeSlotsService)
        {
            this.timeSlotsService = timeSlotsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNextAvailableTimeSlots([FromQuery] int? daysCount = null)
        {
            return Ok(await this.timeSlotsService.GetNextTimeSlots(daysCount.GetValueOrDefault(DEFAULT_DAYS_COUNT)));
        }

        [HttpPost("overrides")]
        [RequireLogin(RoleType.DeliveryCompany)]
        public async Task<IActionResult> InsertOverride([FromBody] TimeSlotOverrideDto timeSlotOverride)
        {
            await this.timeSlotsService.AddTimeSlotOverride(timeSlotOverride);
            return NoContent();
        }
    }
}