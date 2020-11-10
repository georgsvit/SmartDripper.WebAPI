using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Options
{
    public class JWTOptions
    {
        public const string SectionName = "JWTOptions";

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int LifeTime { get; set; }
        public string Key { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}
