using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
