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
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Models;
using SmartDripper.WebAPI.Models.Users;
using SmartDripper.WebAPI.Services;

namespace SmartDripper.WebAPI.Controllers
{
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceService deviceService;

        public DevicesController(DeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        [HttpPost(Routes.DeviceLogin)]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                var response = await deviceService.LoginAsync(loginRequest);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new BadRequestResponse(e.Message));
            }
        }

        [HttpPost(Routes.DeviceRegister)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Register([FromBody] DetailedRegistrationRequest request)
        {
            Device device = new Device(request.Login, request.Password);

            try
            {
                await deviceService.RegisterAsync(device);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new BadRequestResponse(e.Message));
            }
        }

        [HttpPost(Routes.DeviceDelete)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Delete([FromBody] DeviceDeleteRequest request)
        {          
            try
            {
                await deviceService.DeleteAsync(request.deviceId, request.identityId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new BadRequestResponse(e.Message));
            }
        }
    }
}
