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
    public class DiseasesController : ControllerBase
    {
        private readonly DiseaseService diseaseService;

        public DiseasesController(DiseaseService diseaseService)
        {
            this.diseaseService = diseaseService;
        }

        [HttpGet(Routes.Disease.GetAll)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetAll()
        {
            var list = await diseaseService.GetAll();

            return Ok(list);
        }

        [HttpGet(Routes.Disease.Get)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                Disease disease = await diseaseService.GetAsync(id);
                return Ok(disease);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(Routes.Disease.Create)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Create([FromBody] DiseaseRequest request)
        {
            try
            {
                await diseaseService.CreateAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(Routes.Disease.Delete)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await diseaseService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch(Routes.Disease.Edit)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] DiseaseRequest request)
        {
            try
            {
                var disease = await diseaseService.EditAsync(id, request);
                return Ok(disease);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
