using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtImplementation
{
    public class TokenOlusturucu
    {
        public string TokenOlustur()
        {
          var bytes =   Encoding.UTF8.GetBytes("FurkanFurkanFurkan1");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
          
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddSeconds(30),signingCredentials:credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return  handler.WriteToken(token);
        }
        public string TokenAdminRolOlustur()
        {
            var bytes = Encoding.UTF8.GetBytes("FurkanFurkanFurkan1");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"Member")


            };
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", claims: null, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
