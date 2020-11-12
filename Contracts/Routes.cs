using System;
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

        public const string DoctorBase = "doctors";
        public const string DoctorLogin = DoctorBase + "/login";
        public const string DoctorRegister = DoctorBase + "/register";

        public const string DeviceBase = "devices";
        public const string DeviceLogin = DeviceBase + "/login";
        public const string DeviceRegister = DeviceBase + "/register";
        public const string DeviceDelete = DeviceBase + "/delete";
    }
}
