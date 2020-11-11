using SmartDripper.WebAPI.Models.Users;
using System;

namespace SmartDripper.WebAPI.Models
{
    public class Appointment
    {
        private Appointment() { }

        public Appointment(Doctor doctor, Medicament medicament, Patient patient)
        {
            Doctor = doctor;
            Medicament = medicament;
            Patient = patient;
            IsDone = false;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Doctor Doctor { get; set; }
        public Medicament Medicament { get; set; }
        public Patient Patient { get; set; }
        public bool IsDone { get; set; }
    }
}
