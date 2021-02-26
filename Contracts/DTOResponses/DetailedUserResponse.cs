using System;

namespace SmartDripper.WebAPI.Contracts.DTOResponses
{
    public class DetailedUserResponse : JWTTokenResponse
    {
        public DetailedUserResponse(Guid id, string name, string surname, string role, string token, DateTime expireDate)
            : base(token, expireDate)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Role = role;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
    }
}
