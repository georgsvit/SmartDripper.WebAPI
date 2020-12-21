using Microsoft.EntityFrameworkCore;
using SmartDripper.WebAPI.Models;
using SmartDripper.WebAPI.Models.Users;
using System;

namespace SmartDripper.WebAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>().HasOne(d => d.Procedure).WithOne(p => p.Device).HasForeignKey<Procedure>(p => p.DeviceId);
            //AddDefaultAppAdmin(modelBuilder);

            modelBuilder.Entity<MedicalProtocol>().HasOne(mp => mp.Disease).WithMany().HasForeignKey(d => d.DiseaseId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalProtocol>().HasMany(mp => mp.Medicaments).WithOne(m => m.MedicalProtocol).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Manufacturer>().HasMany(m => m.Medicaments).WithOne(m => m.Manufacturer).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicamentLogNote>().HasOne(mln => mln.Medicament).WithMany().HasForeignKey(mln => mln.MedicamentId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>().HasOne(o => o.Medicament).WithMany().HasForeignKey(o => o.MedicamentId).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Medicament>().HasOne(m => m.MedicalProtocol).WithOne().HasForeignKey<MedicalProtocol>(mp => mp.Medicaments).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Medicament>().HasOne(m => m.Manufacturer).WithOne().HasForeignKey<Manufacturer>(m => m.Medicaments).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>().HasOne(d => d.UserIdentity).WithOne().HasForeignKey<Doctor>(d => d.Id).OnDelete(DeleteBehavior.Cascade);
        }

        private void AddDefaultAppAdmin(ModelBuilder builder)
        {
            Guid commonGuid = Guid.Parse("1EC7309F-C97D-412C-B8B8-31C1459CBD41");
            Admin defaultAppAdmin = new Admin(
                "test@test.com", "password", "Admin", "Admin");

            UserIdentity userIdentity = defaultAppAdmin.UserIdentity;
            userIdentity.Id = commonGuid;

            defaultAppAdmin.UserIdentity = null;
            defaultAppAdmin.Id = commonGuid;

            builder.Entity<UserIdentity>().HasData(userIdentity);
            builder.Entity<Admin>().HasData(defaultAppAdmin);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<UserIdentity> UserIdentities { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<MedicalProtocol> MedicalProtocols { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<MedicamentLogNote> MedicamentLogNotes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
    }
}
