using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Authentication
{
    public class RefreshTokenRequestDto
    {
        public string Token { get; set; }
    }
}
