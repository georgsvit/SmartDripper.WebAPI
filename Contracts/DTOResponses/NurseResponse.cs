using SmartDripper.WebAPI.Models;
using SmartDripper.WebAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTOResponses
{
    public class NurseResponse : JWTTokenResponse
    {
        public NurseResponse(string name, string surname, string role, List<Procedure> procedures, string token, DateTime expireDate) 
            : base(token, expireDate)
        {
            Name = name;
            Surname = surname;
            Role = role;
            Procedures = procedures;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public List<Procedure> Procedures { get; set; }
    }
}
