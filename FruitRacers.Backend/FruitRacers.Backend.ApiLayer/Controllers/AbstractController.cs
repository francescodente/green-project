using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    public class AbstractController : ControllerBase
    {
        protected int UserId => int.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}