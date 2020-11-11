using System.Collections.Generic;

namespace SmartDripper.WebAPI.Models.Users
{
    public class Nurse : DetailedUser
    {
        private Nurse() { }

        public Nurse(string login, string password, string name, string surname)
            : base(name, surname, login, password, Roles.NURSE)
        {
            Procedures = new List<Procedure>();
        }

        public List<Procedure> Procedures { get; set; }
    }
}
