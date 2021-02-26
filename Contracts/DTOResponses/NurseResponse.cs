using SmartDripper.WebAPI.Models;
using System;
using System.Collections.Generic;

namespace SmartDripper.WebAPI.Contracts.DTOResponses
{
    public class NurseResponse : JWTTokenResponse
    {
        public NurseResponse(Guid id, string name, string surname, string role, List<Procedure> procedures, string token, DateTime expireDate)
            : base(token, expireDate)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Role = role;
            Procedures = procedures;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public List<Procedure> Procedures { get; set; }
    }
}
