using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTOResponses
{
    public class BadRequestResponse
    {
        public BadRequestResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
