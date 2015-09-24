using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication.OAuthBearer;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;

namespace WebApplication.ResourceServer.Controllers
{
    [Route("[controller]")]
    public class TokenController : Controller
    {
        private readonly OAuthBearerAuthenticationOptions _bearerOptions;
        private readonly SigningCredentials _signingCredentials;

        public TokenController(
            IOptions<OAuthBearerAuthenticationOptions> bearerOptions,
            SigningCredentials signingCredentials)
        {
            _bearerOptions = bearerOptions.Options;
            _signingCredentials = signingCredentials;
        }

        // POST: /token
        [HttpPost]
        public JwtToken Token([FromBody] Credentials credentials)
        {
            // Pretend to validate credentials...

            JwtSecurityTokenHandler handler =
                _bearerOptions.
                SecurityTokenValidators.
                OfType<JwtSecurityTokenHandler>().
                First();

            JwtSecurityToken securityToken = handler.CreateToken(
                issuer: _bearerOptions.TokenValidationParameters.ValidIssuer,
                audience: _bearerOptions.TokenValidationParameters.ValidAudience,
                signingCredentials: _signingCredentials,
                subject: new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "somebody"),
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim(ClaimTypes.Role, "teacher")
                }),
                expires: DateTime.Today.AddDays(1));

            var token = handler.WriteToken(securityToken);

            return new JwtToken
            {
                AccessToken = token,
                TokenType = "bearer"
            };
        }
    }

    public class JwtToken
    {
        public string AccessToken { set; get; }
        public string TokenType { set; get; }
    }

    public class Credentials
    {
        public string User { set; get; }
        public string Password { set; get; }
    }
}
