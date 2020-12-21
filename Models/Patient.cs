using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Models.Users
{
    public class Patient
    {
        private Patient() { }

        public Patient(string name, string surname, string dOB, string comment)
        {
            Name = name;
            Surname = surname;
            DOB = dOB;
            Comment = comment;
            Appointments = new List<Appointment>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }
        public string Comment { get; set; }

        //
        [JsonIgnore]
        public List<Appointment> Appointments { get; set; }

        public List<Appointment> GetPatientCard() =>
            Appointments.Where(a => a.IsDone).ToList();
    }
}
