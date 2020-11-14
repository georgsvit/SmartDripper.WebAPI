using SmartDripper.WebAPI.Models.Users;

namespace SmartDripper.WebAPI.Contracts.DTOResponses
{
    public class DeviceGetAllResponseAdmin : DeviceGetAllResponseNurse
    {
        public Nurse Nurse { get; set; }
    }
}
