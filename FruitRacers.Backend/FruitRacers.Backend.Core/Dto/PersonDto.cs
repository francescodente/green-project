using System;

namespace FruitRacers.Backend.Core.Dto
{
    public class PersonDto : AccountDto
    {
        public string CF { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
    }
}
