﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts
{
    public static class Routes
    {
        public static class Admin
        {
            public const string Base = "admins";

            public const string Login = Base + "/login";
            public const string Register = Base + "/register";
        }

        public static class Nurse
        {
            public const string Base = "nurses";

            public const string Login = Base + "/login";
            public const string Register = Base + "/register";
        }
        
        public static class Doctor
        {
            public const string Base = "doctors";

            public const string Login = Base + "/login";
            public const string Register = Base + "/register";
        }

        public static class Device
        {
            public const string Base = "devices";

            public const string GetAll = Base;
            public const string Get = Base + "/{deviceId}";
            public const string Login = Base + "/login";
            public const string Register = Base + "/register";
            public const string Delete = Base + "/delete";
            public const string Reset = Base + "/{deviceId}/reset";
            public const string Update = Base + "/{deviceId}/update";
            public const string GetConfiguration = Base + "/getconfig";

        }

        public static class Medicament
        {
            public const string Base = "medicaments";

            public const string GetAll = Base;
            public const string Get = Base + "/{Id}";
            public const string Delete = Base + "/delete/{Id}";
            public const string Edit = Base + "/edit/{Id}";
            public const string Create = Base + "/create";

        }
    }
}
