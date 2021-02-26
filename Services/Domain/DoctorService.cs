using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services.Domain
{
    public class DoctorService : GenericUserService
    {
        public DoctorService(ApplicationContext applicationContext, JWTTokenService tokenService, IDataProtectionProvider provider, IStringLocalizer localizer)
            : base(applicationContext, tokenService, provider, localizer) { }

        public async Task<DoctorResponse> LoginAsync(LoginRequest loginRequest)
        {
            var identity = await GetIdentityAsync(loginRequest);
            var user = await applicationContext.Doctors.Include(d => d.UserIdentity).FirstOrDefaultAsync(x => x.Id == identity.Id);
            if (user == null) throw new Exception(localizer["Login failed. The user is not a doctor."]);

            JwtSecurityToken token = tokenService.CreateJWTToken(identity);
            string encodedToken = tokenService.EncodeJWTToken(token);

            return new DoctorResponse(user.UserIdentity.Id, user.Name, user.Surname, identity.Role, user.Appointments, encodedToken, token.ValidTo);
        }
    }
}
