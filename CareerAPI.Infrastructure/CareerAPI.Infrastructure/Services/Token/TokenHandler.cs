using CareerAPI.Application.Abstraction.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CareerAPI.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(int minute)
        {
            var securityKey = _configuration[$"Token:SecurityKey"];
            var issuer = _configuration[$"Token:Issuer"];
            var audience = _configuration[$"Token:Audience"];

            if (string.IsNullOrEmpty(securityKey) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
            {
                throw new InvalidOperationException($"Token configuration for is not properly set.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "my_subject"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(minute),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return new Application.DTOs.Token
            {
                accessToken = tokenHandler.WriteToken(securityToken),
                Expiration = tokenDescriptor.Expires.Value
            };
        }
    }
}
