using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Entities
{
    public class RefreshToken : UserToken
    {
        public string AccessTokenId { get; set; }
    }
}
