using SmartDripper.WebAPI.Models.Users;
using System;

namespace SmartDripper.WebAPI.Models
{
    public class Procedure
    {
        private Procedure() { }

        public Procedure(Guid nurseId, Guid deviceId, Guid appointmentId)
        {
            NurseId = nurseId;
            DeviceId = deviceId;
            AppointmentId = appointmentId;
            IsAutonomous = false;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid? NurseId { get; set; }
        public Guid? DeviceId { get; set; }
        public Guid? AppointmentId { get; set; }
        public bool IsAutonomous { get; set; }

        //
        public Device Device { get; set; }
        public Appointment Appointment { get; set; }
        public Nurse Nurse { get; set; }
    }
}
