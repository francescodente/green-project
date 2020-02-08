﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.ApiLayer.Authentication
{
    public class PasswordGenerationSettings
    {
        public string AllowedCharacters { get; set; }
        public int Length { get; set; }
    }
}
