using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class DiseaseRequest
    {
        public string Title { get; set; }
        public string SymptomUk { get; set; }
        public string SymptomUa { get; set; }
    }
}
