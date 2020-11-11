using System;

namespace SmartDripper.WebAPI.Models
{
    public class MedicamentLogNote
    {
        private MedicamentLogNote() { }

        public MedicamentLogNote(Medicament medicament)
        {
            Medicament = medicament;
            Date = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        //
        public Medicament Medicament { get; set; }
    }
}
