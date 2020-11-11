using SmartDripper.WebAPI.Models.Users.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Models.Users
{
    public class Nurse : DetailedUser
    {
        private Nurse() { }

        public Nurse(string login, string password, string name, string surname)
            : base(login, password, Roles.NURSE, name, surname) 
        {
            Procedures = new List<Procedure>();
        }

        public List<Procedure> Procedures { get; set; }
    }
}
