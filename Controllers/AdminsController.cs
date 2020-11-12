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
    public class AdminsController : ControllerBase
    {
        private readonly AdminService adminService;

        public AdminsController(AdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpPost(Routes.Admin.Login)]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                var response = await adminService.LoginAsync(loginRequest);
                return Ok(response);
            } catch (Exception e)
            {
                return BadRequest(new BadRequestResponse(e.Message));
            }
        }

        [HttpPost(Routes.Admin.Register)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        public async Task<IActionResult> Register([FromBody] DetailedRegistrationRequest request)
        {
            Admin admin = new Admin(request.Login, request.Password, request.Name, request.Surname);

            try
            {
                await adminService.RegisterAsync(admin);
                return Ok();
            } catch (Exception e)
            {
                return BadRequest(new BadRequestResponse(e.Message));
            }
        }
    }
}
