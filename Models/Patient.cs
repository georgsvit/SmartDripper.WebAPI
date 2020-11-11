using System;
using System.Collections.Generic;

namespace SmartDripper.WebAPI.Models.Users
{
    public class Patient
    {
        private Patient() { }

        public Patient(string name, string surname, DateTime dOB, string comment)
        {
            Name = name;
            Surname = surname;
            DOB = dOB;
            Comment = comment;
            PatientCard = new List<PatientsLogNote>();
            Appointments = new List<Appointment>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string Comment { get; set; }

        //
        public List<PatientsLogNote> PatientCard { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
