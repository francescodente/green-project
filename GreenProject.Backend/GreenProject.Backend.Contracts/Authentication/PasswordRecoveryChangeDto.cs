using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Authentication
{
    public class PasswordRecoveryChangeDto
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
