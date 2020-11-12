using System;

namespace SmartDripper.WebAPI.Models
{
    public class Order
    {
        private Order() { }

        public Order(Guid medicamentId, int count)
        {
            MedicamentId = medicamentId;
            Count = count;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid? MedicamentId { get; set; }
        public int Count { get; set; }

        //
        public Medicament Medicament { get; set; }
    }
}
