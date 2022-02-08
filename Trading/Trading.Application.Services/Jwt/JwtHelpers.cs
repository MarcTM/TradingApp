using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Trading.Application.Services.Jwt
{
    public class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(UserTokens userAccounts)
        {
            var claims = new Claim[]
            {
                new Claim("Guid", userAccounts.Guid.ToString()),
                new Claim("Username", userAccounts.Username),
                new Claim("Email", userAccounts.Email),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };

            return claims;
        }

        public static UserTokens GenTokenkey(UserTokens model, JwtSettings jwtSettings)
        {
            var UserToken = new UserTokens();

            var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
            DateTime expireTime = DateTime.UtcNow.AddDays(1);

            var JWToken = new JwtSecurityToken(
                issuer: jwtSettings.ValidIssuer,
                audience: jwtSettings.ValidAudience,
                claims: GetClaims(model),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(expireTime).DateTime,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            UserToken.Token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            UserToken.Guid = model.Guid;
            UserToken.Username = model.Username;
            UserToken.Email = model.Email;
            UserToken.Validaty = expireTime.TimeOfDay;

            return UserToken;
        }
    }
}
