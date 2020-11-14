using System;
using System.Collections.Generic;

namespace SmartDripper.WebAPI.Models
{
    public class MedicalProtocol
    {
        private MedicalProtocol() { }

        public MedicalProtocol(Guid diseaseId, string title, string description, double maxTemp, double minTemp, int maxPulse, int minPulse, int maxBloodPressure, int minBloodPressure)
        {
            DiseaseId = diseaseId;
            Title = title;
            Description = description;
            MaxTemp = maxTemp;
            MinTemp = minTemp;
            MaxPulse = maxPulse;
            MinPulse = minPulse;
            MaxBloodPressure = maxBloodPressure;
            MinBloodPressure = minBloodPressure;
            Medicaments = new List<Medicament>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid? DiseaseId { get; set; }
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
