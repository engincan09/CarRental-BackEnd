using ReCapProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectEntities.DTOs
{
    public class CustomerDetailDto : IDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}
