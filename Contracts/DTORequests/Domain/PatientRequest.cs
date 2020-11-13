using System;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class PatientRequest
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string Comment { get; set; }
    }
}
