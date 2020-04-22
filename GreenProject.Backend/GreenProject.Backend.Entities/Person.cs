using System;

namespace GreenProject.Backend.Entities
{
    public class Person : Role
    {
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
    }
}
