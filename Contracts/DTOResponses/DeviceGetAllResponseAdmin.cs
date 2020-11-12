using SmartDripper.WebAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTOResponses
{
    public class DeviceGetAllResponseAdmin : DeviceGetAllResponseNurse
    {
        public Nurse Nurse { get; set; }
    }
}
