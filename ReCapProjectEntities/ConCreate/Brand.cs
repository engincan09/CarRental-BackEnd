using ReCapProjectEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectEntities.ConCreate
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
