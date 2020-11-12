using System;

namespace SmartDripper.WebAPI.Models.Users
{
    public class PatientsLogNote
    {
        private PatientsLogNote() { }

        public PatientsLogNote(Guid patientId)
        {
            PatientId = patientId;
            Date = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid? PatientId { get; set; }
        public DateTime Date { get; set; }

        //
        public Patient Patient { get; set; }
    }
}
