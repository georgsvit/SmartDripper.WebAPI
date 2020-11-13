using System;

namespace SmartDripper.WebAPI.Contracts.DTOResponses
{
    public class PatientResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string Comment { get; set; }
    }
}
