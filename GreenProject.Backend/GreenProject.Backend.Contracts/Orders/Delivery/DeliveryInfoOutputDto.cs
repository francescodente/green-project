﻿using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Contracts.TimeSlots;
using System;

namespace GreenProject.Backend.Contracts.Orders
{
    public class DeliveryInfoOutputDto
    {
        public string Notes { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public AddressOutputDto Address { get; set; }
        public TimeSlotDto TimeSlot { get; set; }
    }
}