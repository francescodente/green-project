﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Dto
{
    public class RegistrationDto<T>
        where T : AccountDto
    {
        public T Account { get; set; }
        public string Password { get; set; }
    }
}