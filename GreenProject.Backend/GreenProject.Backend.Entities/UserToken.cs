using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Entities
{
    public abstract class UserToken
    {
        public string Token { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsInvalid { get; set; }
        public bool IsUsed { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
