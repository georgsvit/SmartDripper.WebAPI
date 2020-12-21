using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDripper.WebAPI.Contracts;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Models;
using SmartDripper.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
    public class DataController : ControllerBase
    {
        private readonly DataService dataService;

        public DataController(DataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpPost(Routes.Data.Import)]
        public async Task<IActionResult> ImportData([FromForm] IFormFile file)
        {
            byte[] fileContentBytes = await ReadFileContentBytes(file);
            //await dataService.ImportAsync(fileContentBytes);
            return Ok();
        }

        [HttpGet(Routes.Data.Export)]
        public async Task<IActionResult> ExportData()
        {
            byte[] fileContent = await dataService.ExportAsync();
            return File(fileContent, "text/plain");
        }

        private async Task<byte[]> ReadFileContentBytes(IFormFile importDataRequest)
        {
            byte[] fileContentBytes;
            using (var readStream = importDataRequest.OpenReadStream())
            {
                fileContentBytes = new byte[readStream.Length];
                await readStream.ReadAsync(fileContentBytes, 0, (int)readStream.Length);
            }

            return fileContentBytes;
        }
    }
}
