using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class ManufacturerRequest
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
