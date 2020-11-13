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
            public const string Delete = Base + "/delete/{deviceId}";
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

        public static class Disease
        {
            public const string Base = "diseases";

            public const string GetAll = Base;
            public const string Get = Base + "/{Id}";
            public const string Delete = Base + "/delete/{Id}";
            public const string Edit = Base + "/edit/{Id}";
            public const string Create = Base + "/create";
        }

        public static class MedicalProtocol
        {
            public const string Base = "medicalprotocols";

            public const string GetAll = Base;
            public const string Get = Base + "/{Id}";
            public const string Delete = Base + "/delete/{Id}";
            public const string Edit = Base + "/edit/{Id}";
            public const string Create = Base + "/create";
        }

        public static class Manufacturer
        {
            public const string Base = "manufacturers";

            public const string GetAll = Base;
            public const string Get = Base + "/{Id}";
            public const string Delete = Base + "/delete/{Id}";
            public const string Edit = Base + "/edit/{Id}";
            public const string Create = Base + "/create";
        }

        public static class Patient
        {
            public const string Base = "patients";

            public const string GetAll = Base;
            public const string Get = Base + "/{Id}";
            public const string Delete = Base + "/delete/{Id}";
            public const string Edit = Base + "/edit/{Id}";
            public const string Create = Base + "/create";
        }

        public static class Appointment
        {
            public const string Base = "appointments";

            public const string GetAll = Base;
            public const string Get = Base + "/{Id}";
            public const string Delete = Base + "/delete/{Id}";
            public const string Edit = Base + "/edit/{Id}";
            public const string Create = Base + "/create";
            public const string Done = Base + "/done/{Id}";
        }

        public static class Procedure
        {
            public const string Base = "procedures";

            public const string GetAll = Base;
            public const string Get = Base + "/{Id}";
            public const string Delete = Base + "/delete/{Id}";
            public const string Edit = Base + "/edit/{Id}";
            public const string Create = Base + "/create";
        }
    }
}
