using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Models.Users
{
    public class UserIdentity
    {
        private UserIdentity() { }

        public UserIdentity(Guid id, string login, string password, string role)
        {
            Id = id;
            Login = login;
            Password = password;
            Role = role;
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
