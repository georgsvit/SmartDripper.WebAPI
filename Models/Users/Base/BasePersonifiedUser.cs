using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Models.Users.Base
{
    public class BasePersonifiedUser : BaseUser
    {
        protected BasePersonifiedUser() { }

        public BasePersonifiedUser(string name, string surname, string login, string password, string role) 
            : base(login, password, role)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
