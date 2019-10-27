using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.MEasurementUnits
{
    public interface IMeasurementUnitsService
    {
        Task<IEnumerable<string>> GetAllMeasurementUnits();
    }
}
