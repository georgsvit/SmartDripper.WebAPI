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
