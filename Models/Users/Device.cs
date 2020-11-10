﻿using SmartDripper.WebAPI.Models.Users.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Models.Users
{
    public enum DeviceState
    {
        Inactive,
        Active,
        Blocked
    }

    public class Device : BaseUser
    {
        private Device() { }

        public Device(string login, string password, string name, string surname)
            : base(login, password, Roles.DEVICE) 
        {
            State = DeviceState.Inactive;
            IsTurnedOn = false;
            Procedure = null;
        }

        public Procedure Procedure { get; set; }
        public DeviceState State { get; set; }
        public bool IsTurnedOn { get; set; }
    }
}