using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartDripper.WebAPI.Models
{
    public class Medicament
    {
        private Medicament() { }

        public Medicament(string title, string description, int amountInPack, Guid manufacturerId, Guid medicalProtocolId)
        {
            Title = title;
            Description = description;
            AmountInPack = amountInPack;
            Lack = 0;
            ManufacturerId = manufacturerId;
            MedicalProtocolId = medicalProtocolId;
            Appointments = new List<Appointment>();
            MedicamentLogNotes = new List<MedicamentLogNote>();
            Orders = new List<Order>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid? ManufacturerId { get; set; }
        public Guid? MedicalProtocolId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int Lack { get; set; }
        public int AmountInPack { get; set; }

        //
        public Manufacturer Manufacturer { get; set; }
        public MedicalProtocol MedicalProtocol { get; set; }

        [JsonIgnore]
        public List<Appointment> Appointments { get; set; }
        public List<MedicamentLogNote> MedicamentLogNotes { get; set; }
        public List<Order> Orders { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Medicament medicament &&
                   Id.Equals(medicament.Id) &&
                   Title == medicament.Title &&
                   Description == medicament.Description &&
                   EqualityComparer<Guid?>.Default.Equals(ManufacturerId, medicament.ManufacturerId) &&
                   EqualityComparer<Guid?>.Default.Equals(MedicalProtocolId, medicament.MedicalProtocolId) &&
                   EqualityComparer<Manufacturer>.Default.Equals(Manufacturer, medicament.Manufacturer) &&
                   EqualityComparer<MedicalProtocol>.Default.Equals(MedicalProtocol, medicament.MedicalProtocol) &&
                   EqualityComparer<List<Appointment>>.Default.Equals(Appointments, medicament.Appointments) &&
                   EqualityComparer<List<MedicamentLogNote>>.Default.Equals(MedicamentLogNotes, medicament.MedicamentLogNotes) &&
                   EqualityComparer<List<Order>>.Default.Equals(Orders, medicament.Orders);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Title);
            hash.Add(Description);
            hash.Add(ManufacturerId);
            hash.Add(MedicalProtocolId);
            hash.Add(Manufacturer);
            hash.Add(MedicalProtocol);
            hash.Add(Appointments);
            hash.Add(MedicamentLogNotes);
            hash.Add(Orders);
            return hash.ToHashCode();
        }
    }
}
