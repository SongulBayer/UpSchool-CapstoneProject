using FinalProject.Application.Common.Interfaces;
using FinalProject.Application.Common.Models.Auth;
using FinalProject.Domain.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Services
{
    public class JwtManager : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        //appsettings.json da oluşturduğumuz obje rotasyonunu geçtik
        public JwtManager(IOptions<JwtSettings> jwtSettingsOption)
        {
            _jwtSettings = jwtSettingsOption.Value;
        }
        public JwtDto Generate(string userId, string email, string firstName, string lastName, List<string>? roles = null)
        {
            //payload kısmındaki her bir dataya claim denir 
            var claims = new List<Claim>()
            {
                  new Claim("uid", userId),
                new Claim(JwtRegisteredClaimNames.Email,email),
                new Claim(JwtRegisteredClaimNames.Sub,userId),
                new Claim(JwtRegisteredClaimNames.GivenName,firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,lastName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };
            //Stringi Byte arrayer çevirmek için encodin.utf8 kullanılıabilir
            var symetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var signingCredentials = new SigningCredentials(symetricKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryInMinutes),
                signingCredentials: signingCredentials

                );
            var accessToken=new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return new JwtDto(accessToken, DateTime.Now.AddMinutes(_jwtSettings.ExpiryInMinutes));
        }
    }
}
