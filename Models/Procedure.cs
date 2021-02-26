using SmartDripper.WebAPI.Models.Users;
using System;

namespace SmartDripper.WebAPI.Models
{
    public class Procedure
    {
        private Procedure() { }

        public Procedure(Guid nurseId, Guid deviceId, Guid appointmentId, int? speed, int? volume)
        {
            NurseId = nurseId;
            DeviceId = deviceId;
            AppointmentId = appointmentId;
            Speed = speed == null ? 0 : speed;
            Volume = volume == null ? 0 : volume;
            IsAutonomous = false;
            Id = Guid.NewGuid();

            Temperature = 0;
            Pulse = 0;
            BloodPressure = 0;
            HasProblem = false;
        }

        public Guid Id { get; set; }
        public Guid? NurseId { get; set; }
        public Guid? DeviceId { get; set; }
        public Guid? AppointmentId { get; set; }
        public bool IsAutonomous { get; set; }

        public int? Speed { get; set; }
        public int? Volume { get; set; }
        public double? Temperature { get; set; }
        public int? Pulse { get; set; }
        public int? BloodPressure { get; set; }
        public bool HasProblem { get; set; }

        //
        public Device Device { get; set; }
        public Appointment Appointment { get; set; }
        public Nurse Nurse { get; set; }
    }
}
