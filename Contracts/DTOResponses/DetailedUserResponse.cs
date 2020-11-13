using System;

namespace SmartDripper.WebAPI.Contracts.DTOResponses
{
    public class DetailedUserResponse : JWTTokenResponse
    {
        public DetailedUserResponse(string name, string surname, string role, string token, DateTime expireDate)
            : base(token, expireDate)
        {
            Name = name;
            Surname = surname;
            Role = role;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
    }
}
