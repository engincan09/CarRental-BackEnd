using ReCapProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectEntities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public int FindeksPoint { get; set; }
    }
}
