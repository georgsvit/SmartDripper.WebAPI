using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper mapper;

        public DevicesController(DeviceService deviceService, IMapper mapper)
        {
            this.deviceService = deviceService;
            this.mapper = mapper;
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

        // TODO: Return device with all adjacent objects (now only device)

        [HttpGet(Routes.DeviceGetAll)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.NURSE)]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Device> devices = await deviceService.GetAllDevicesAsync();
            
            if (User.IsInRole(Roles.ADMIN))
            {
                //var response = mapper.Map<List<DeviceGetAllResponseAdmin>>(devices);
                return Ok(devices);
            }
            
            if (User.IsInRole(Roles.NURSE))
            {
                //var response = mapper.Map<List<DeviceGetAllResponseNurse>>(devices.Where(d => d.State == DeviceState.Inactive));
                return Ok(devices.Where(d => d.State == DeviceState.Inactive));
            }

            return BadRequest();
        }

        // TODO: Return device with all adjacent objects (now only device)

        [HttpGet(Routes.DeviceGet)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.NURSE)]
        public async Task<IActionResult> GetOneAsync([FromRoute] Guid deviceId)
        {
            try
            {
                Device device = await deviceService.GetOneAsync(deviceId);
                return Ok(device);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(Routes.DeviceReset)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.NURSE)]
        public async Task<IActionResult> ResetAsync([FromRoute] Guid deviceId, [FromBody] DeviceResetRequest request)
        {
            try
            {
                await deviceService.ResetAsync(deviceId, request.NewPassword);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch(Routes.DeviceUpdate)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.NURSE)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid deviceId, [FromBody] DeviceUpdateRequest request)
        {
            try
            {
                await deviceService.UpdateConfigurationAsync(deviceId, request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet(Routes.DeviceGetConfiguration)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.DEVICE)]
        public async Task<IActionResult> GetConfigurationAsync()
        {
            var deviceId = Guid.Parse(User.Identity.Name);
            try
            {
                Device device = await deviceService.GetOneAsync(deviceId);
                return Ok(device);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
