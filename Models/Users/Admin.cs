namespace SmartDripper.WebAPI.Models.Users
{
    public class Admin : DetailedUser
    {
        private Admin() { }

        public Admin(string login, string password, string name, string surname)
            : base(name, surname, login, password, Roles.ADMIN) { }
    }
}
