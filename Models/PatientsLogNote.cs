using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Models.Users
{
    public class PatientsLogNote
    {
        private PatientsLogNote() { }

        public PatientsLogNote(Patient patient)
        {
            Patient = patient;
            Date = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
    }
}
