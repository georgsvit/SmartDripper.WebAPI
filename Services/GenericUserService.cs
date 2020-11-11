﻿using Microsoft.EntityFrameworkCore;
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

        protected GenericUserService(ApplicationContext applicationContext, JWTTokenService tokenService)
        {
            this.applicationContext = applicationContext;
            this.tokenService = tokenService;
        }

        public async Task RegisterUserAsync<TUser>(TUser user) where TUser : User
        {
            if (await IsUserRegisteredAsync(user))
            {
                throw new Exception("The user with such login is already registered.");
            }

            //SecurePassword(user);
            await applicationContext.Set<TUser>().AddAsync(user);
            await applicationContext.SaveChangesAsync();
        }

        //protected async Task<UserIdentity> GetUserIdentityAsync()

        //private void SecurePassword<TUser>(TUser user) where TUser : User =>
        //    user.UserIdentity.Password = passwordService.GeneratePassword(user.UserIdentity.Password);

        private async Task<bool> IsUserRegisteredAsync<TUser>(TUser user) where TUser : User
        {
            UserIdentity registeredIdentity = await GetUserIdentityByLoginAsync(user.UserIdentity.Login);
            bool isAlreadyRegistered = registeredIdentity != null;
            return isAlreadyRegistered;
        }

        private async Task<UserIdentity> GetUserIdentityByLoginAsync(string login) =>
            await applicationContext.UserIdentities.FirstOrDefaultAsync(identity => identity.Login == login);
    }
}
