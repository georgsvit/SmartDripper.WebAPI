using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Models
{
    public class Medicament
    {
        private Medicament() { }

        public Medicament(string title, string description, Manufacturer manufacturer, MedicalProtocol medicalProtocol)
        {
            Title = title;
            Description = description;
            Manufacturer = manufacturer;
            MedicalProtocol = medicalProtocol;
            Appointments = new List<Appointment>();
            MedicamentLogNotes = new List<MedicamentLogNote>();
            Orders = new List<Order>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //
        public Manufacturer Manufacturer { get; set; }
        public MedicalProtocol MedicalProtocol { get; set; }
        public List<Appointment> Appointments { get; set; }

        public List<MedicamentLogNote> MedicamentLogNotes { get; set; }
        public List<Order> Orders { get; set; }
    }
}
