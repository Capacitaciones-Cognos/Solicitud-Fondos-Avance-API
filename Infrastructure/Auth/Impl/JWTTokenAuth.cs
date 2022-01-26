using Microsoft.IdentityModel.Tokens;
using Solicitud_Fondos_Avance_API.Dtos.commons;
using Solicitud_Fondos_Avance_API.Infrastructure.Interfaces.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Infrastructure.Auth.Impl
{
    public class JWTTokenAuth : IJWTTokenAuth
    {
        private readonly string secretKey;

        public JWTTokenAuth(string secretKey)
        {
            this.secretKey = secretKey;
        }

        public string authenticate(AuthenticateDto authenticateDto)
        {
            if (authenticateDto.username.Equals("test") && authenticateDto.password.Equals("adminadmin"))
            {
                string issuerParam = "issuer";
                string audienceParam = "audience";

                var tokenKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
                var signingCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256);
                
                var token = new JwtSecurityToken(issuerParam, expires: DateTime.Now.AddMinutes(1), signingCredentials: signingCredentials, audience: audienceParam);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return null;
        }
    }
}
