using ReCapProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectCore.Utilities.Security.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }

    }
}
