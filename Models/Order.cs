using System;

namespace SmartDripper.WebAPI.Models
{
    public class Order
    {
        private Order() { }

        public Order(Medicament medicament, int count)
        {
            Medicament = medicament;
            Count = count;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int Count { get; set; }

        //
        public Medicament Medicament { get; set; }
    }
}
