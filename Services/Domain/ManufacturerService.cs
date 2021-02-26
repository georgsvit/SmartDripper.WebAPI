using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Data;
using SmartDripper.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services.Domain
{
    public class ManufacturerService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;
        private readonly IStringLocalizer localizer;

        public ManufacturerService(ApplicationContext applicationContext, IDataProtectionProvider provider, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("ManufacturerService");
            this.localizer = localizer;
        }

        public async Task CreateAsync(ManufacturerRequest request)
        {
            Manufacturer manufacturer = new Manufacturer(request.Name, request.Country);

            var inBase = await applicationContext.Manufacturers.FirstOrDefaultAsync(x => x.Name == request.Name && x.Country == request.Country);

            if (inBase != null) throw new Exception(localizer["Manufacturer already exists."]);

            await applicationContext.Manufacturers.AddAsync(manufacturer);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<List<Manufacturer>> GetAll() =>
            await applicationContext.Manufacturers.ToListAsync();

        public async Task<Manufacturer> GetAsync(Guid id)
        {
            Manufacturer manufacturer = await applicationContext.Manufacturers.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (manufacturer == null) throw new Exception(localizer["Manufacturer with this identifier doesn`t exist."]);

            return manufacturer;
        }

        public async Task DeleteAsync(Guid id)
        {
            Manufacturer manufacturer = applicationContext.Manufacturers.Find(id);

            if (manufacturer == null) throw new Exception(localizer["Manufacturer with this identifier doesn`t exist."]);

            applicationContext.Manufacturers.Remove(manufacturer);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Manufacturer> EditAsync(Guid id, ManufacturerRequest request)
        {
            Manufacturer newManufacturer = new Manufacturer(request.Name, request.Country);
            Manufacturer manufacturer = await GetAsync(id);

            if (manufacturer == null) throw new Exception(localizer["Manufacturer with this identifier doesn`t exist."]);

            manufacturer = newManufacturer;
            manufacturer.Id = id;

            applicationContext.Manufacturers.Update(manufacturer);
            await applicationContext.SaveChangesAsync();

            return await GetAsync(manufacturer.Id);
        }
    }
}
