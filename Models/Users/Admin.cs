using SmartDripper.WebAPI.Models.Users.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Models.Users
{
    public class Admin : BasePersonifiedUser
    {
        private Admin() { }

        public Admin(string login, string password, string name, string surname)
            : base(login, password, Roles.ADMIN, name, surname) { }
    }
}
