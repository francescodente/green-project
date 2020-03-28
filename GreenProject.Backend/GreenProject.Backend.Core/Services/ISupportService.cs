﻿using GreenProject.Backend.Contracts.Support;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface ISupportService
    {
        Task SendSupportEmail(SupportRequestDto request);
    }
}