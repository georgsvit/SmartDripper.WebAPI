﻿using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Data;
using SmartDripper.WebAPI.Models.Users;
using System;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services
{
    public abstract class GenericUserService
    {
        protected readonly ApplicationContext applicationContext;
        protected readonly JWTTokenService tokenService;
        protected readonly IDataProtector dataProtector;

        protected GenericUserService(ApplicationContext applicationContext, JWTTokenService tokenService, IDataProtectionProvider provider)
        {
            this.applicationContext = applicationContext;
            this.tokenService = tokenService;
            this.dataProtector = provider.CreateProtector("GenericUserService");
        }

        public async Task RegisterAsync<TUser>(TUser user) where TUser : User
        {
            if (await IsRegisteredAsync(user))
            {
                throw new Exception("The user with such login is already registered.");
            }

            ProtectPassword(user);
            await applicationContext.Set<TUser>().AddAsync(user);
            await applicationContext.SaveChangesAsync();
        }

        protected async Task<UserIdentity> GetIdentityAsync(LoginRequest request)
        {
            var identity = await GetIdentityByLoginAsync(request.Login);

            if (identity == null) throw new Exception("The user with such login doesn`t exist.");

            var invalidPassword = dataProtector.Unprotect(identity.Password) != request.Password;

            if (invalidPassword) throw new Exception("The password inn`t correct");

            return identity;
        }

        private void ProtectPassword<TUser>(TUser user) where TUser : User =>
            user.UserIdentity.Password = dataProtector.Protect(user.UserIdentity.Password);

        private async Task<bool> IsRegisteredAsync<TUser>(TUser user) where TUser : User
        {
            UserIdentity identity = await GetIdentityByLoginAsync(user.UserIdentity.Login);
            return identity != null;
        }

        private async Task<UserIdentity> GetIdentityByLoginAsync(string login) =>
            await applicationContext.UserIdentities.FirstOrDefaultAsync(identity => identity.Login == login);
    }
}
