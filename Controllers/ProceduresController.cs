using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDripper.WebAPI.Contracts;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Models;
using SmartDripper.WebAPI.Services.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Controllers
{
    [ApiController]
    public class ProceduresController : ControllerBase
    {
        private readonly ProcedureService procedureService;
        private readonly OrderService orderService;
        private readonly MedicamentLogNoteService noteService;
        private readonly DeviceService deviceService;
        private readonly AppointmentService appointmentService;

        public ProceduresController(ProcedureService procedureService, OrderService orderService, MedicamentLogNoteService noteService, DeviceService deviceService, AppointmentService appointmentService)
        {
            this.procedureService = procedureService;
            this.orderService = orderService;
            this.noteService = noteService;
            this.deviceService = deviceService;
            this.appointmentService = appointmentService;
        }

        [HttpGet(Routes.Procedure.GetAll)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.NURSE)]
        public async Task<IActionResult> GetAll()
        {
            var list = await procedureService.GetAll();

            await appointmentService.GetAll();

            if (User.IsInRole(Roles.NURSE))
            {
                return Ok(list.Where(p => p.NurseId == new Guid(User.Identity.Name)).ToList());
            }

            return Ok(list);
        }

        [HttpGet(Routes.Procedure.Get)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                Procedure procedure = await procedureService.GetAsync(id);
                return Ok(procedure);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(Routes.Procedure.Create)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.NURSE)]
        public async Task<IActionResult> Create([FromBody] ProcedureRequest request)
        {
            try
            {
                if (request.NurseId == null)
                {
                    request.NurseId = new Guid(User.Identity.Name);
                }

                await procedureService.CreateAsync(request);
                appointmentService.SetDoneAsync((Guid)request.AppointmentId).Wait();

                var procedure = await procedureService.GetProcedureByAppointmentId((Guid)request.AppointmentId);
                await deviceService.SetDeviceStateAsync((Guid)request.DeviceId, Models.Users.DeviceState.Active);
                await orderService.AddOrder((Guid)procedure.Appointment.MedicamentId, 1);
                await noteService.AddNote((Guid)procedure.Appointment.MedicamentId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(Routes.Procedure.Delete)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.NURSE)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await procedureService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch(Routes.Procedure.Edit)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.NURSE)]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] ProcedureRequest request)
        {
            try
            {
                if (User.IsInRole(Roles.NURSE))
                {
                    request.NurseId = new Guid(User.Identity.Name);
                }

                var procedure = await procedureService.EditAsync(id, request);
                return Ok(procedure);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
