﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartDripper.WebAPI.Data;

namespace SmartDripper.WebAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201221232051_procedure_hasproblem_added")]
    partial class procedure_hasproblem_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MedicamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("MedicamentId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Disease", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SymptomUa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SymptomUk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.MedicalProtocol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DiseaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaxBloodPressure")
                        .HasColumnType("int");

                    b.Property<int>("MaxPulse")
                        .HasColumnType("int");

                    b.Property<double>("MaxTemp")
                        .HasColumnType("float");

                    b.Property<int>("MinBloodPressure")
                        .HasColumnType("int");

                    b.Property<int>("MinPulse")
                        .HasColumnType("int");

                    b.Property<double>("MinTemp")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.ToTable("MedicalProtocols");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Medicament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountInPack")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lack")
                        .HasColumnType("int");

                    b.Property<Guid?>("ManufacturerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MedicalProtocolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("MedicalProtocolId");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.MedicamentLogNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MedicamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MedicamentId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MedicamentId");

                    b.HasIndex("MedicamentId1");

                    b.ToTable("MedicamentLogNotes");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<Guid?>("MedicamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MedicamentId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MedicamentId");

                    b.HasIndex("MedicamentId1");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Procedure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("BloodPressure")
                        .HasColumnType("int");

                    b.Property<Guid?>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HasProblem")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAutonomous")
                        .HasColumnType("bit");

                    b.Property<Guid?>("NurseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Pulse")
                        .HasColumnType("int");

                    b.Property<int?>("Speed")
                        .HasColumnType("int");

                    b.Property<double?>("Temperature")
                        .HasColumnType("float");

                    b.Property<int?>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("DeviceId")
                        .IsUnique()
                        .HasFilter("[DeviceId] IS NOT NULL");

                    b.HasIndex("NurseId");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Users.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserIdentityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserIdentityId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Users.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsTurnedOn")
                        .HasColumnType("bit");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<Guid>("UserIdentityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserIdentityId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Users.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserIdentityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Users.Nurse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserIdentityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserIdentityId");

                    b.ToTable("Nurses");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Users.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Users.UserIdentity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserIdentities");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Appointment", b =>
                {
                    b.HasOne("SmartDripper.WebAPI.Models.Users.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId");

                    b.HasOne("SmartDripper.WebAPI.Models.Medicament", "Medicament")
                        .WithMany("Appointments")
                        .HasForeignKey("MedicamentId");

                    b.HasOne("SmartDripper.WebAPI.Models.Users.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.MedicalProtocol", b =>
                {
                    b.HasOne("SmartDripper.WebAPI.Models.Disease", "Disease")
                        .WithMany()
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Medicament", b =>
                {
                    b.HasOne("SmartDripper.WebAPI.Models.Manufacturer", "Manufacturer")
                        .WithMany("Medicaments")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartDripper.WebAPI.Models.MedicalProtocol", "MedicalProtocol")
                        .WithMany("Medicaments")
                        .HasForeignKey("MedicalProtocolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.MedicamentLogNote", b =>
                {
                    b.HasOne("SmartDripper.WebAPI.Models.Medicament", "Medicament")
                        .WithMany()
                        .HasForeignKey("MedicamentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartDripper.WebAPI.Models.Medicament", null)
                        .WithMany("MedicamentLogNotes")
                        .HasForeignKey("MedicamentId1");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Order", b =>
                {
                    b.HasOne("SmartDripper.WebAPI.Models.Medicament", "Medicament")
                        .WithMany()
                        .HasForeignKey("MedicamentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartDripper.WebAPI.Models.Medicament", null)
                        .WithMany("Orders")
                        .HasForeignKey("MedicamentId1");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Procedure", b =>
                {
                    b.HasOne("SmartDripper.WebAPI.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId");

                    b.HasOne("SmartDripper.WebAPI.Models.Users.Device", "Device")
                        .WithOne("Procedure")
                        .HasForeignKey("SmartDripper.WebAPI.Models.Procedure", "DeviceId");

                    b.HasOne("SmartDripper.WebAPI.Models.Users.Nurse", "Nurse")
                        .WithMany("Procedures")
                        .HasForeignKey("NurseId");
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Users.Admin", b =>
                {
                    b.HasOne("SmartDripper.WebAPI.Models.Users.UserIdentity", "UserIdentity")
                        .WithMany()
                        .HasForeignKey("UserIdentityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Users.Device", b =>
                {
                    b.HasOne("SmartDripper.WebAPI.Models.Users.UserIdentity", "UserIdentity")
                        .WithMany()
                        .HasForeignKey("UserIdentityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Users.Doctor", b =>
                {
                    b.HasOne("SmartDripper.WebAPI.Models.Users.UserIdentity", "UserIdentity")
                        .WithOne()
                        .HasForeignKey("SmartDripper.WebAPI.Models.Users.Doctor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartDripper.WebAPI.Models.Users.Nurse", b =>
                {
                    b.HasOne("SmartDripper.WebAPI.Models.Users.UserIdentity", "UserIdentity")
                        .WithMany()
                        .HasForeignKey("UserIdentityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
