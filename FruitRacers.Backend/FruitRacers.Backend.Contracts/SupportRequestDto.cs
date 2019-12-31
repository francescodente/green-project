using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts
{
    public class SupportRequestDto
    {
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
