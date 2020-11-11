﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts
{
    public static class Routes
    {
        public const string AdminBase = "admins";
        public const string AdminLogin = AdminBase + "/login";
        public const string AdminRegister = AdminBase + "/register";

        public const string NurseBase = "nurses";
        public const string NurseLogin = NurseBase + "/login";
        public const string NurseRegister = NurseBase + "/register";
    }
}