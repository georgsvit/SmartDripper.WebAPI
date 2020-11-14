using System;

namespace SmartDripper.WebAPI.Contracts.DTOResponses
{
    public class JWTTokenResponse
    {
        public JWTTokenResponse(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }

        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
