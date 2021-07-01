using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SignalRAuth.Models;

namespace SignalRAuth.Handlers
{
    public class TokenHandler
    {
        readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Token CreateAccessToken(int duration)
        {
            Token tokenInstance = new Token();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            tokenInstance.Expiration = DateTime.Now.AddMinutes(duration);
            JwtSecurityToken securityToken = new JwtSecurityToken
            (
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: tokenInstance.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin")
                }
            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            tokenInstance.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenInstance.RefreshToken = CreateRefreshToken();
            return tokenInstance;
        }
        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
