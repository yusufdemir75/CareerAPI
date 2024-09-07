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
    public class CustomerTokenHandler : ICustomerTokenHandler
    {
        private readonly IConfiguration _configuration;

        public CustomerTokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(int minute, string tokenType)
        {
            // Konfigürasyon değerlerini alıyoruz
            var securityKey = _configuration[$"Token:{tokenType}SecurityKey"];
            var issuer = _configuration[$"Token:{tokenType}Issuer"];
            var audience = _configuration[$"Token:{tokenType}Audience"];

            // Null kontrolü yapıyoruz
            if (string.IsNullOrEmpty(securityKey) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
            {
                throw new InvalidOperationException($"Token configuration for '{tokenType}' is not properly set.");
            }

            // SecurityKey ve SigningCredentials ayarlarını yapıyoruz
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Token ayarlarını yapıyoruz
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "my_subjectt"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                // Diğer claim'ler buraya eklenebilir
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
