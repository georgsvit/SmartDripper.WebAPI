using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class AppointmentRequest
    {
        public Guid? MedicamentId { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? DoctorId { get; set; }
    }
}
