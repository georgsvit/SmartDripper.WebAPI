﻿using Microsoft.AspNetCore.DataProtection;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services
{
    public class DeviceService : GenericUserService
    {
        public DeviceService(ApplicationContext applicationContext, JWTTokenService tokenService, IDataProtectionProvider provider) 
            : base(applicationContext, tokenService, provider) { }

        public async Task<DeviceResponse> LoginAsync(LoginRequest loginRequest)
        {
            var identity = await GetIdentityAsync(loginRequest);
            var user = await applicationContext.Devices.FindAsync(identity.Id);
            if (user == null) throw new Exception("Login failed. The user is not an device.");

            JwtSecurityToken token = tokenService.CreateJWTToken(identity);
            string encodedToken = tokenService.EncodeJWTToken(token);

            return new DeviceResponse(user.State, user.IsTurnedOn, encodedToken, token.ValidTo);
        }
    }
}