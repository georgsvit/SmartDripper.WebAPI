using SmartDripper.WebAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTOResponses
{
    public class DeviceResponse : JWTTokenResponse
    {
        public DeviceResponse(DeviceState state, bool isTurnedOn, string token, DateTime expireDate) 
            : base(token, expireDate)
        {
            State = state;
            IsTurnedOn = isTurnedOn;
        }

        public DeviceState State { get; set; }
        public bool IsTurnedOn { get; set; }
    }
}
