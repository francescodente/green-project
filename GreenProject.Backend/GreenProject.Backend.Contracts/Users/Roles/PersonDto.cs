using GreenProject.Backend.Entities;
using System;

namespace GreenProject.Backend.Contracts.Users.Roles
{
    public class PersonDto : RoleDto
    {
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
    }
}
