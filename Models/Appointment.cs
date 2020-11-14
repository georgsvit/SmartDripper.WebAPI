using SmartDripper.WebAPI.Models.Users;
using System;

namespace SmartDripper.WebAPI.Models
{
    public class Appointment
    {
        private Appointment() { }

        public Appointment(Guid medicamentId, Guid patientId, Guid doctorId)
        {
            Id = Guid.NewGuid();
            MedicamentId = medicamentId;
            PatientId = patientId;
            DoctorId = doctorId;
            Date = DateTime.Now;
            IsDone = false;
        }

        public Guid Id { get; set; }
        public Guid? MedicamentId { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? DoctorId { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }

        //
        public Doctor Doctor { get; set; }
        public Medicament Medicament { get; set; }
        public Patient Patient { get; set; }

        public void SetDone()
        {
            IsDone = true;
            Date = DateTime.Now;
        }
    }
}
