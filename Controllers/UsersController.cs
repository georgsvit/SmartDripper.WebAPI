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
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;

        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet(Routes.User.GetAll)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetAll([FromRoute] string role)
        {
            var list = await userService.GetAll(role);

            return Ok(list);
        }

        [HttpPost(Routes.User.Create)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Create([FromRoute] string role, [FromBody] DetailedRegistrationRequest request)
        {
            try
            {
                await userService.CreateAsync(request, role);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(Routes.User.Delete)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Delete([FromRoute] string role, [FromRoute] Guid id)
        {
            try
            {
                await userService.DeleteAsync(id, role);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch(Routes.User.Edit)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Edit([FromRoute] string role, [FromRoute] Guid id, [FromBody] DetailedRegistrationRequest request)
        {
            try
            {
                await userService.EditAsync(id, request, role);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
