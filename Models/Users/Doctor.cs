using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartDripper.WebAPI.Models.Users
{
    public class Doctor : DetailedUser
    {
        private Doctor() { }

        public Doctor(string login, string password, string name, string surname)
            : base(name, surname, login, password, Roles.DOCTOR)
        {
            Appointments = new List<Appointment>();
        }

        [JsonIgnore]
        public List<Appointment> Appointments { get; set; }
    }
}
