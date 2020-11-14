using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDripper.WebAPI.Contracts;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Models;
using SmartDripper.WebAPI.Services.Domain;
using System;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Controllers
{
    [ApiController]
    public class MedicalProtocolsController : ControllerBase
    {
        private readonly MedicalProtocolService medicalProtocolService;

        public MedicalProtocolsController(MedicalProtocolService medicalProtocolService)
        {
            this.medicalProtocolService = medicalProtocolService;
        }

        [HttpGet(Routes.MedicalProtocol.GetAll)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetAll()
        {
            var list = await medicalProtocolService.GetAll();

            return Ok(list);
        }

        [HttpGet(Routes.MedicalProtocol.Get)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                MedicalProtocol medicalProtocol = await medicalProtocolService.GetAsync(id);
                return Ok(medicalProtocol);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(Routes.MedicalProtocol.Create)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Create([FromBody] MedicalProtocolRequest request)
        {
            try
            {
                await medicalProtocolService.CreateAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(Routes.MedicalProtocol.Delete)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await medicalProtocolService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch(Routes.MedicalProtocol.Edit)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] MedicalProtocolRequest request)
        {
            try
            {
                var medicalProtocol = await medicalProtocolService.EditAsync(id, request);
                return Ok(medicalProtocol);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
