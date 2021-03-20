using ReCapProjectCore.Entities;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectEntities.DTOs
{
    public class RentalPaymentDto : IDto
    {
        public Rental Rental { get; set; }
        public Payment Payment { get; set; }
    }
}
