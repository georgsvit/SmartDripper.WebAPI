using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDripper.WebAPI.Contracts;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Models;
using SmartDripper.WebAPI.Services.Domain;
using System;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Controllers
{
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService patientService;

        public PatientsController(PatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet(Routes.Patient.GetAll)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.DOCTOR)]
        public async Task<IActionResult> GetAll()
        {
            var list = await patientService.GetAll();

            return Ok(list);
        }

        [HttpGet(Routes.Patient.Get)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                PatientResponse patient = await patientService.GetPatientResponseAsync(id);
                return Ok(patient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(Routes.Patient.Create)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Create([FromBody] PatientRequest request)
        {
            try
            {
                await patientService.CreateAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(Routes.Patient.Delete)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await patientService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch(Routes.Patient.Edit)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] PatientRequest request)
        {
            try
            {
                var patient = await patientService.EditAsync(id, request);
                return Ok(patient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
