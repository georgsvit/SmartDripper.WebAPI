using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Models
{
    public class MedicalProtocol
    {
        private MedicalProtocol() { }

        public MedicalProtocol(string title, string description, double maxTemp, double minTemp, int maxPulse, int minPulse, int maxBloodPressure, int minBloodPressure, Disease disease)
        {
            Title = title;
            Description = description;
            MaxTemp = maxTemp;
            MinTemp = minTemp;
            MaxPulse = maxPulse;
            MinPulse = minPulse;
            MaxBloodPressure = maxBloodPressure;
            MinBloodPressure = minBloodPressure;
            Disease = disease;
            Medicaments = new List<Medicament>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
        public int MaxPulse { get; set; }
        public int MinPulse { get; set; }
        public int MaxBloodPressure { get; set; }
        public int MinBloodPressure { get; set; }

        //
        public List<Medicament> Medicaments { get; set; }
        public Disease Disease { get; set; }
    }
}
