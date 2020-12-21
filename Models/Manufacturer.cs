using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartDripper.WebAPI.Models
{
    public class Manufacturer
    {
        private Manufacturer() { }

        public Manufacturer(string name, string country)
        {
            Name = name;
            Country = country;
            Medicaments = new List<Medicament>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        //
        [JsonIgnore]
        public List<Medicament> Medicaments { get; set; }
    }
}
