using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FruitRacers.Backend.ApiLayer
{
    public static class ControllerExtensions
    {
        public static int GetUserId(this ControllerBase controller)
        {
            return int.Parse(controller.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
