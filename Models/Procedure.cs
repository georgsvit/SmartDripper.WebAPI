using SmartDripper.WebAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Models
{
    public class Procedure
    {
        private Procedure() { }

        public Procedure(Guid deviceId, Appointment appointment, Nurse nurse)
        {
            DeviceId = deviceId;
            Appointment = appointment;
            Nurse = nurse;
            IsAutonomous = false;
            Device = null;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
        public bool IsAutonomous { get; set; }
        public Appointment Appointment { get; set; }
        public Nurse Nurse { get; set; }
    }
}
