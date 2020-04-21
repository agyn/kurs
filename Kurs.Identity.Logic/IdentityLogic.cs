using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Kurs.Identity.Logic
{
    public class IdentityLogic : IIdentityLogic
    {
        private readonly IConfiguration _config;
        private readonly X509Certificate2 _cert;

        public IdentityLogic(IConfiguration config, X509Certificate2 cert)
        {
            _config = config;
            _cert = cert;
        }

        public string GenerateAccessToken(int userId)
        {
            var secondsStr = _config["IdentityConfig:AccessExpirationSeconds"];
            if (!int.TryParse(secondsStr, out var seconds))
                seconds = (int)TimeSpan.FromMinutes(30).TotalSeconds;
            return GenerateToken(userId, seconds);
        }

        public string GenerateRefreshToken(int userId)
        {
            var secondsStr = _config["IdentityConfig:RefreshExpirationSeconds"];
            if (!int.TryParse(secondsStr, out var seconds))
                seconds = (int)TimeSpan.FromDays(30).TotalSeconds;
            return GenerateToken(userId, seconds);
        }

        private string GenerateToken(int userId, int seconds)
        {
            var issuer = _config["IdentityConfig:Issuer"];
            var claims = new List<Claim>() { new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()) };
            var creds = new SigningCredentials(new X509SecurityKey(_cert), SecurityAlgorithms.RsaSha256);
            // var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["IdentityConfig:SigningKey"])),
            // 				SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddSeconds(seconds);

            var token = new JwtSecurityToken(
                issuer,
                null,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}