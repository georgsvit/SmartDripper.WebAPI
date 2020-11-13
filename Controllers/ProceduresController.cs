using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDripper.WebAPI.Contracts;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Models;
using SmartDripper.WebAPI.Services;

namespace SmartDripper.WebAPI.Controllers
{
    [ApiController]
    public class ProceduresController : ControllerBase
    {
        private readonly ProcedureService procedureService;

        public ProceduresController(ProcedureService procedureService)
        {
            this.procedureService = procedureService;
        }

        [HttpGet(Routes.Procedure.GetAll)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetAll()
        {
            var list = await procedureService.GetAll();

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Create([FromBody] ProcedureRequest request)
        {
            try
            {
                await procedureService.CreateAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(Routes.Procedure.Delete)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] ProcedureRequest request)
        {
            try
            {
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
