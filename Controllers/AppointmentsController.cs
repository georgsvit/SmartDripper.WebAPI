﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDripper.WebAPI.Contracts;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Models;
using SmartDripper.WebAPI.Services.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Controllers
{
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService appointmentService;

        public AppointmentsController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpGet(Routes.Appointment.GetAll)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.DOCTOR + "," + Roles.NURSE)]
        public async Task<IActionResult> GetAll()
        {
            var list = await appointmentService.GetAll();

            if (User.IsInRole(Roles.NURSE))
            {
                return Ok(list.Where(a => !a.IsDone).ToList());
            }

            return Ok(list);
        }

        [HttpGet(Routes.Appointment.Get)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.DOCTOR + "," + Roles.NURSE)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                Appointment appointment = await appointmentService.GetAsync(id);
                return Ok(appointment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(Routes.Appointment.Create)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.DOCTOR)]
        public async Task<IActionResult> Create([FromBody] AppointmentRequest request)
        {
            try
            {
                await appointmentService.CreateAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(Routes.Appointment.Delete)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.DOCTOR)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await appointmentService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch(Routes.Appointment.Edit)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.DOCTOR)]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] AppointmentRequest request)
        {
            try
            {
                var appointment = await appointmentService.EditAsync(id, request);
                return Ok(appointment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(Routes.Appointment.Done)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN + "," + Roles.DOCTOR + "," + Roles.NURSE)]
        public async Task<IActionResult> Done([FromRoute] Guid id)
        {
            try
            {
                await appointmentService.SetDoneAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
