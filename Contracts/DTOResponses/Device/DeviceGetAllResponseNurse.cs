using SmartDripper.WebAPI.Models;
using SmartDripper.WebAPI.Models.Users;

namespace SmartDripper.WebAPI.Contracts.DTOResponses
{
    public class DeviceGetAllResponseNurse
    {
        public Device Device { get; set; }
        public Procedure Procedure { get; set; }
        public Appointment Appointment { get; set; }
        public Medicament Medicament { get; set; }
        public MedicalProtocol MedicalProtocol { get; set; }
        public Disease Disease { get; set; }
        public Patient Patient { get; set; }
    }
}
