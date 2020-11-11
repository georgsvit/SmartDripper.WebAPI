using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
