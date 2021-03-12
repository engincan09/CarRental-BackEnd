using ReCapProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectEntities.DTOs
{
    public class CarRentalDto : IDto
    {
        public int RentalId { get; set; }
        public string CarName{get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
