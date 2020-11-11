using Microsoft.AspNetCore.DataProtection;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services
{
    public class AdminService : GenericUserService
    {
        public AdminService(ApplicationContext applicationContext, JWTTokenService tokenService, IDataProtectionProvider provider)
            : base(applicationContext, tokenService, provider) { }

        public async Task<DetailedUserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var identity = await GetIdentityAsync(loginRequest);
            var user = await applicationContext.Admins.FindAsync(identity.Id);
            if (user == null) throw new Exception("Login failed. The user is not an admin.");

            JwtSecurityToken token = tokenService.CreateJWTToken(identity);
            string encodedToken = tokenService.EncodeJWTToken(token);

            return new DetailedUserResponse(user.Name, user.Surname, identity.Role, encodedToken, token.ValidTo);
        }
    }
}
