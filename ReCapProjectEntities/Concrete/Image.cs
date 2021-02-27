using Microsoft.AspNetCore.Http;
using ReCapProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectEntities.Concrete
{
    public class Image : IEntity
    {
        public IFormFile Files { get; set; }
    }
}
