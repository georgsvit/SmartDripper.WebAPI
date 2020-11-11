using System.Collections.Generic;

namespace SmartDripper.WebAPI.Models.Users
{
    public class Doctor : DetailedUser
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
