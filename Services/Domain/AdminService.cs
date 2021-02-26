using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Localization;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services.Domain
{
    public class AdminService : GenericUserService
    {
        public AdminService(ApplicationContext applicationContext, JWTTokenService tokenService, IDataProtectionProvider provider, IStringLocalizer localizer)
            : base(applicationContext, tokenService, provider, localizer) { }

        public async Task<DetailedUserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var identity = await GetIdentityAsync(loginRequest);
            var user = await applicationContext.Admins.FindAsync(identity.Id);
            if (user == null) throw new Exception(localizer["Login failed. The user is not an admin."]);

            JwtSecurityToken token = tokenService.CreateJWTToken(identity);
            string encodedToken = tokenService.EncodeJWTToken(token);

            return new DetailedUserResponse(user.Id, user.Name, user.Surname, identity.Role, encodedToken, token.ValidTo);
        }
    }
}
