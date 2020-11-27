using SmartDripper.WebAPI.Models;
using SmartDripper.WebAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts
{
    public class DataDTO
    {
        private DataDTO() { }

        public DataDTO(List<Admin> admins, 
                       List<Device> devices, 
                       List<Doctor> doctors, 
                       List<Nurse> nurses, 
                       List<UserIdentity> userIdentities, 
                       List<Appointment> appointments, 
                       List<Disease> diseases, 
                       List<Manufacturer> manufacturers, 
                       List<MedicalProtocol> medicalProtocols, 
                       List<Medicament> medicaments, 
                       List<MedicamentLogNote> medicamentLogNotes, 
                       List<Order> orders, 
                       List<Patient> patients, 
                       List<Procedure> procedures)
        {
            Admins = admins;
            Devices = devices;
            Doctors = doctors;
            Nurses = nurses;
            UserIdentities = userIdentities;
            Appointments = appointments;
            Diseases = diseases;
            Manufacturers = manufacturers;
            MedicalProtocols = medicalProtocols;
            Medicaments = medicaments;
            MedicamentLogNotes = medicamentLogNotes;
            Orders = orders;
            Patients = patients;
            Procedures = procedures;
        }

        public List<Admin> Admins { get; set; }
        public List<Device> Devices { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Nurse> Nurses { get; set; }
        public List<UserIdentity> UserIdentities { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Disease> Diseases { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public List<MedicalProtocol> MedicalProtocols { get; set; }
        public List<Medicament> Medicaments { get; set; }
        public List<MedicamentLogNote> MedicamentLogNotes { get; set; }
        public List<Order> Orders { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Procedure> Procedures { get; set; }
    }
}
