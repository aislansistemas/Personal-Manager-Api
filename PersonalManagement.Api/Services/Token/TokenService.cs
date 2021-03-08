using Microsoft.IdentityModel.Tokens;
using PersonalManagement.Api.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManagement.Api.Services.Token
{
    public static class TokenService
    {
        private static string _secret = "bm5mZ2Zqa3Ryc2xyaW92eGRhLnNhZGFzXGRhd3dxZXcuL2FzZGE+KjNkPz5zd2RkLiUyM2Rhc2ExMjIxLi8=";
        public static string GenerateToken(UserAccount user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(GetSecretToken());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Name.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string GetSecretToken()
        {
            return _secret;
        }
    }
}
