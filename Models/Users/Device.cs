using System.Text.Json.Serialization;

namespace SmartDripper.WebAPI.Models.Users
{
    public enum DeviceState
    {
        Inactive,
        Active,
        Blocked
    }

    public class Device : User
    {
        private Device() { }

        public Device(string login, string password)
            : base(login, password, Roles.DEVICE)
        {
            State = DeviceState.Inactive;
            IsTurnedOn = false;
            Procedure = null;
        }

        [JsonIgnore]
        public Procedure Procedure { get; set; }
        public DeviceState State { get; set; }
        public bool IsTurnedOn { get; set; }

        public void Activate(string hashedPassword)
        {
            State = DeviceState.Active;
            UserIdentity.Password = hashedPassword;
        }
    }
}