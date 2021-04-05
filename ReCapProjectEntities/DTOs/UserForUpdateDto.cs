using ReCapProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectEntities.DTOs
{
    public class UserForUpdateDto
    {
        public User User { get; set; }
        public string Password { get; set; }
    }
}
