﻿using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.Contracts.TimeSlots;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/timeslots")]
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
        [RequireLogin]
        public async Task<IActionResult> GetNextAvailableTimeSlots([FromQuery] int? daysCount = null)
        {
            return Ok(await this.timeSlotsService.GetNextTimeSlots(daysCount.GetValueOrDefault(DEFAULT_DAYS_COUNT)));
        }

        [HttpPost("overrides")]
        [RequireLogin(UserRole.DeliveryCompany)]
        public async Task<IActionResult> InsertOverride([FromBody] TimeSlotOverrideDto timeSlotOverride)
        {
            await this.timeSlotsService.AddTimeSlotOverride(timeSlotOverride);
            return NoContent();
        }
    }
}