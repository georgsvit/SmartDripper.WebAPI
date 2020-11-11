namespace SmartDripper.WebAPI.Models.Users
{
    public class DetailedUser : User
    {
        protected DetailedUser() { }

        public DetailedUser(string name, string surname, string login, string password, string role)
            : base(login, password, role)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
