using Microsoft.EntityFrameworkCore;
using SmartDripper.WebAPI.Data;
using SmartDripper.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services.Domain
{
    public class OrderService
    {
        private readonly ApplicationContext applicationContext;

        public OrderService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task AddOrder(Guid medicamentId, int count)
        {
            var medicament = await applicationContext.Medicaments.SingleOrDefaultAsync(x => x.Id == medicamentId);

            medicament.Lack += count;

            if (medicament.Lack + count >= medicament.AmountInPack)
            {
                medicament.Lack %= medicament.AmountInPack;
                var order = new Order(medicamentId, count);
                await applicationContext.Orders.AddAsync(order);
            }
           
            await applicationContext.SaveChangesAsync();
        } 
    }
}
