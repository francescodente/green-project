using System;

namespace GreenProject.Backend.Core.Entities
{
    public class Person : Role
    {
        public string Cf { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
