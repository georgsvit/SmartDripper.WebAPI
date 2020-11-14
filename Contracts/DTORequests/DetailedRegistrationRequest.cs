namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class DetailedRegistrationRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
