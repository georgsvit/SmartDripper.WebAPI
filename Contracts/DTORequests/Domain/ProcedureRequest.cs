using System;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class ProcedureRequest
    {
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
    }
}
