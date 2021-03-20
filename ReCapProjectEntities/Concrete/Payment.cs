using ReCapProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectEntities.Concrete
{
    public class Payment : IEntity
    {
        public decimal Amount { get; set; }
    }
}
