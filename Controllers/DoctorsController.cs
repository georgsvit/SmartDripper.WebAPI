using Microsoft.AspNetCore.Mvc;
using SmartDripper.WebAPI.Contracts;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Models.Users;
using SmartDripper.WebAPI.Services.Domain;
using System;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Controllers
{
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorService doctorService;

        public DoctorsController(DoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [HttpPost(Routes.Doctor.Login)]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                var response = await doctorService.LoginAsync(loginRequest);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new BadRequestResponse(e.Message));
            }
        }

        [HttpPost(Routes.Doctor.Register)]
        public async Task<IActionResult> Register([FromBody] DetailedRegistrationRequest request)
        {
            Doctor doctor = new Doctor(request.Login, request.Password, request.Name, request.Surname);

            try
            {
                await doctorService.RegisterAsync(doctor);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new BadRequestResponse(e.Message));
            }
        }
    }
}
