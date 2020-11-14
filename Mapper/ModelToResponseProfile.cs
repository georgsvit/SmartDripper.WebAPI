using AutoMapper;
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Models.Users;

namespace SmartDripper.WebAPI.Mapper
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<Device, DeviceGetAllResponseNurse>()
                .BeforeMap((d, r) => r.Device = d)
                .BeforeMap((d, r) => r.Appointment = d.Procedure.Appointment)
                .BeforeMap((d, r) => r.Procedure = d.Procedure)
                .BeforeMap((d, r) => r.Medicament = d.Procedure.Appointment.Medicament)
                .BeforeMap((d, r) => r.Patient = d.Procedure.Appointment.Patient)
                .BeforeMap((d, r) => r.MedicalProtocol = d.Procedure.Appointment.Medicament.MedicalProtocol)
                .BeforeMap((d, r) => r.Disease = d.Procedure.Appointment.Medicament.MedicalProtocol.Disease);

            CreateMap<Device, DeviceGetAllResponseAdmin>()
                .BeforeMap((d, r) => r.Device = d)
                .BeforeMap((d, r) => r.Nurse = d.Procedure.Nurse)
                .BeforeMap((d, r) => r.Appointment = d.Procedure.Appointment)
                .BeforeMap((d, r) => r.Procedure = d.Procedure)
                .BeforeMap((d, r) => r.Medicament = d.Procedure.Appointment.Medicament)
                .BeforeMap((d, r) => r.Patient = d.Procedure.Appointment.Patient)
                .BeforeMap((d, r) => r.MedicalProtocol = d.Procedure.Appointment.Medicament.MedicalProtocol)
                .BeforeMap((d, r) => r.Disease = d.Procedure.Appointment.Medicament.MedicalProtocol.Disease);
        }
    }
}
