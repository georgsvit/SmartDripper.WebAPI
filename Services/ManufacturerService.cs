using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Data;
using SmartDripper.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services
{
    public class ManufacturerService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;

        public ManufacturerService(ApplicationContext applicationContext, IDataProtectionProvider provider)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("ManufacturerService");
        }

        public async Task CreateAsync(ManufacturerRequest request)
        {
            Manufacturer manufacturer = new Manufacturer(request.Name, request.Country);

            var inBase = await applicationContext.Manufacturers.FirstOrDefaultAsync(x => x.Name == request.Name && x.Country == request.Country);

            if (inBase != null) throw new Exception("Manufacturer already exists.");

            await applicationContext.Manufacturers.AddAsync(manufacturer);
            await applicationContext.SaveChangesAsync();
        }

        // TODO: Get all adjacent data
        public async Task<List<Manufacturer>> GetAll() =>
            await applicationContext.Manufacturers.ToListAsync();

        // TODO: Get all adjacent data
        public async Task<Manufacturer> GetAsync(Guid id)
        {
            Manufacturer manufacturer = await applicationContext.Manufacturers.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (manufacturer == null) throw new Exception("Manufacturer with this identifier doesn`t exist.");

            return manufacturer;
        }

        public async Task DeleteAsync(Guid id)
        {
            Manufacturer manufacturer = applicationContext.Manufacturers.Find(id);

            if (manufacturer == null) throw new Exception("Manufacturer with this identifier doesn`t exist.");

            applicationContext.Manufacturers.Remove(manufacturer);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Manufacturer> EditAsync(Guid id, ManufacturerRequest request)
        {
            Manufacturer newManufacturer = new Manufacturer(request.Name, request.Country);
            Manufacturer manufacturer = await GetAsync(id);

            if (manufacturer == null) throw new Exception("Manufacturer with this identifier doesn`t exist.");

            manufacturer = newManufacturer;
            manufacturer.Id = id;

            applicationContext.Manufacturers.Update(manufacturer);
            applicationContext.SaveChanges();

            return await GetAsync(manufacturer.Id);
        }
    }
}
