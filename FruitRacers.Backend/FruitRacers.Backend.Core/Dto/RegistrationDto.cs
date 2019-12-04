using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Dto
{
    public class RegistrationDto<TRole>
        where TRole : RoleDto
    {
        public AccountDto<SimpleUserDto, TRole> Account { get; set; }
        public string Password { get; set; }
    }
}
