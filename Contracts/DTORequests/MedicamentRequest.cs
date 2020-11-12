using SmartDripper.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class MedicamentRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ManufacturerId { get; set; }
        public Guid MedicalProtocolId { get; set; }
    }
}
