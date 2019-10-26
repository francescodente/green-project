using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Users
{
    public class PersonDto : AccountDto
    {
        public string CF { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
    }
}
