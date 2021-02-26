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
    public class NurseService : GenericUserService
    {
        public NurseService(ApplicationContext applicationContext, JWTTokenService tokenService, IDataProtectionProvider provider, IStringLocalizer localizer)
            : base(applicationContext, tokenService, provider, localizer) { }

        public async Task<NurseResponse> LoginAsync(LoginRequest loginRequest)
        {
            var identity = await GetIdentityAsync(loginRequest);
            var user = await applicationContext.Nurses.FindAsync(identity.Id);
            if (user == null) throw new Exception(localizer["Login failed. The user is not a nurse."]);

            JwtSecurityToken token = tokenService.CreateJWTToken(identity);
            string encodedToken = tokenService.EncodeJWTToken(token);

            return new NurseResponse(identity.Id, user.Name, user.Surname, identity.Role, user.Procedures, encodedToken, token.ValidTo);
        }
    }
}
