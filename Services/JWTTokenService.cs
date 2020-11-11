using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartDripper.WebAPI.Models.Users;
using SmartDripper.WebAPI.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SmartDripper.WebAPI.Services
{
    public class JWTTokenService
    {
        private readonly JWTOptions jWTOptions;

        public JWTTokenService(IOptions<JWTOptions> jWTOptions)
        {
            this.jWTOptions = jWTOptions.Value;
        }

        public JwtSecurityToken CreateJWTToken(UserIdentity identity)
        {
            var now = DateTime.UtcNow;
            var JWTToken = new JwtSecurityToken(
                issuer: jWTOptions.Issuer,
                audience: jWTOptions.Audience,
                notBefore: now,
                claims: GetClaims(identity),
                expires: now.Add(TimeSpan.FromMinutes(jWTOptions.LifeTime)),
                signingCredentials: new SigningCredentials(
                    key: jWTOptions.GetSymmetricSecurityKey(),
                    algorithm: SecurityAlgorithms.HmacSha256)
            );
            return JWTToken;
        }

        public string EncodeJWTToken(JwtSecurityToken JWTToken) =>
            new JwtSecurityTokenHandler().WriteToken(JWTToken);

        private IEnumerable<Claim> GetClaims(UserIdentity identity)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, identity.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, identity.Role)
            };
            return claims;
        }
    }
}