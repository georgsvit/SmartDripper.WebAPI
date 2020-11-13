using System;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class AppointmentRequest
    {
        public Guid? MedicamentId { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? DoctorId { get; set; }
    }
}
