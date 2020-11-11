using System;

namespace SmartDripper.WebAPI.Models.Users
{
    public abstract class User
    {
        protected User() { }

        protected User(string login, string password, string role)
        {
            Id = Guid.NewGuid();
            UserIdentity = new UserIdentity(Id, login, password, role);
        }

        public Guid Id { get; set; }
        public UserIdentity UserIdentity { get; set; }
    }
}
