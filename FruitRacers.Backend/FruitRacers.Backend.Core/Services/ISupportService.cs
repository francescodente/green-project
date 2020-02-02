using FruitRacers.Backend.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface ISupportService
    {
        Task SendSupportEmail(SupportRequestDto request);
    }
}
