using System;

namespace FruitRacers.Backend.Contracts.Users.Roles
{
    public class PersonDto : RoleDto
    {
        public string Cf { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public override RoleTypeDto RoleType => RoleTypeDto.Person;
    }
}
