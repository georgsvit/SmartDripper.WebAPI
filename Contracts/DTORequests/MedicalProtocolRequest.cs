using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class MedicalProtocolRequest
    {
        public Guid? DiseaseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
        public int MaxPulse { get; set; }
        public int MinPulse { get; set; }
        public int MaxBloodPressure { get; set; }
        public int MinBloodPressure { get; set; }
    }
}
