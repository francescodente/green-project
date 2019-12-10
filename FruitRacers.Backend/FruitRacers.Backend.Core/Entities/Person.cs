using FruitRacers.Backend.Core.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public class Person : AbstractRole
    {
        public string Cf { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
