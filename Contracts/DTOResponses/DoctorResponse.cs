using SmartDripper.WebAPI.Models;
using System;
using System.Collections.Generic;

namespace SmartDripper.WebAPI.Contracts.DTOResponses
{
    public class DoctorResponse : JWTTokenResponse
    {
        public DoctorResponse(Guid id, string name, string surname, string role, List<Appointment> appointments, string token, DateTime expireDate)
            : base(token, expireDate)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Role = role;
            Appointments = appointments;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
