﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace AuthorizationServer
{
    internal class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            var clientId = string.Empty;
            var clientSecret = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId,out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }
            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId","clientId is not set");
                return Task.FromResult<object>(null);
            }
            var audience = AudienceStore.FindAudience(context.ClientId);
            if (audience==null)
            {
                context.SetError("invalid_clientId", $"Invalid Client ID {context.ClientId}");
                return Task.FromResult<object>(null);
            }

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin",new[] {"*"});
            if (context.UserName != context.Password)
            {
                context.SetError("invaild_grant","The user name or password is incorrect");
                return Task.FromResult<object>(null);
            }
            var identity=new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name,context.UserName));
            identity.AddClaim(new Claim("sub",context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role,"user"));
            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                {
                    "audience",context.ClientId ?? string.Empty
                }
            });
            var ticket=new AuthenticationTicket(identity,properties);
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }
    }
}