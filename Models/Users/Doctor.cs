using SmartDripper.WebAPI.Models.Users.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Models.Users
{
    public class Doctor : BasePersonifiedUser
    {
        private Doctor() { }

        public Doctor(string login, string password, string name, string surname)
            : base(login, password, Roles.DOCTOR, name, surname) 
        {
            Appointments = new List<Appointment>();
        }

        public List<Appointment> Appointments { get; set; }
    }
}
