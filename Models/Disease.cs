using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Models
{
    public class Disease
    {
        private Disease() { }

        public Disease(string title, string symptomUk, string symptomUa)
        {
            Title = title;
            SymptomUk = symptomUk;
            SymptomUa = symptomUa; 
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SymptomUk { get; set; }
        public string SymptomUa { get; set; }
    }
}
