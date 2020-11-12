using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDripper.WebAPI.Contracts;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Models.Users;
using SmartDripper.WebAPI.Services;

namespace SmartDripper.WebAPI.Controllers
{
    [ApiController]
    public class NursesController : ControllerBase
    {
        private readonly NurseService nurseService;

        public NursesController(NurseService nurseService)
        {
            this.nurseService = nurseService;
        }

        [HttpPost(Routes.Nurse.Login)]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                var response = await nurseService.LoginAsync(loginRequest);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new BadRequestResponse(e.Message));
            }
        }

        [HttpPost(Routes.Nurse.Register)]
        public async Task<IActionResult> Register([FromBody] DetailedRegistrationRequest request)
        {
            Nurse nurse = new Nurse(request.Login, request.Password, request.Name, request.Surname);

            try
            {
                await nurseService.RegisterAsync(nurse);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new BadRequestResponse(e.Message));
            }
        }
    }
}
