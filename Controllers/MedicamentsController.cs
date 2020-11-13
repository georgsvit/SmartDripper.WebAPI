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
    public class MedicamentsController : ControllerBase
    {
        private readonly MedicamentService medicamentService;

        public MedicamentsController(MedicamentService medicamentService)
        {
            this.medicamentService = medicamentService;
        }

        [HttpGet(Routes.Medicament.GetAll)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.DOCTOR)]
        public async Task<IActionResult> GetAll()
        {
            var list = await medicamentService.GetAll();

            return Ok(list);
        }

        [HttpGet(Routes.Medicament.Get)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.DOCTOR)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                Medicament medicament = await medicamentService.GetAsync(id);
                return Ok(medicament);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(Routes.Medicament.Create)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.DOCTOR)]
        public async Task<IActionResult> Create([FromBody] MedicamentRequest request)
        {
            try
            {
                await medicamentService.CreateAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(Routes.Medicament.Delete)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.DOCTOR)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await medicamentService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch(Routes.Medicament.Edit)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.DOCTOR)]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] MedicamentRequest request)
        {
            try
            {
                var medicament = await medicamentService.EditAsync(id, request);
                return Ok(medicament);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
