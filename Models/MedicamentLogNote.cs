using System;

namespace SmartDripper.WebAPI.Models
{
    public class MedicamentLogNote
    {
        private MedicamentLogNote() { }

        public MedicamentLogNote(Guid medicamentId)
        {
            MedicamentId = medicamentId;
            Date = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid? MedicamentId { get; set; }
        public DateTime Date { get; set; }

        //
        public Medicament Medicament { get; set; }
    }
}
