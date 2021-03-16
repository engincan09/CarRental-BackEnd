using ReCapProjectCore.Entities;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectEntities.DTOs
{
    public class CarDetailAndImageDto : IDto
    {
        public CarDetailDto Car { get; set; }
        public List<CarImage>Images { get; set; }
    }
}
