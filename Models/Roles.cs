namespace SmartDripper.WebAPI.Models
{
    public static class Roles
    {
        public const string ADMIN = "ADMIN";
        public const string NURSE = "NURSE";
        public const string DOCTOR = "DOCTOR";
        public const string DEVICE = "DEVICE";

        public static string[] GetAllRoles()
        {
            return new string[]
            {
                ADMIN,
                NURSE,
                DOCTOR,
                DEVICE
            };
        }
    }
}
