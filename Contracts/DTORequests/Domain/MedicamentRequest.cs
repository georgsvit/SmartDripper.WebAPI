using System;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class MedicamentRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AmountInPack { get; set; }
        public Guid ManufacturerId { get; set; }
        public Guid MedicalProtocolId { get; set; }
    }
}
