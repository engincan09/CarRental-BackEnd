using ReCapProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectEntities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int  Id { get; set; }
        public string Description { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public decimal DailyPrice { get; set; }
        public List<string> ImagePaths { get; set; }
        public int ModelYear { get; set; }
        

    }
}
