using Microsoft.AspNetCore.Http;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class ImportDataRequest
    {
        public IFormFile FormFile { get; set; }
    }
}
