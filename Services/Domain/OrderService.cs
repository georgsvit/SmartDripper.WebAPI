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
            var order = new Order(medicamentId, count);

            await applicationContext.Orders.AddAsync(order);
            await applicationContext.SaveChangesAsync();
        } 
    }
}
