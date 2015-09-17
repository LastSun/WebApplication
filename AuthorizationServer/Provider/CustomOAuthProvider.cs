using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CodeFirstModelFromDB;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace AuthorizationServer
{
    internal class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }
            if (clientId == null)
            {
                context.SetError("invalid_clientId", "clientId is not set");
                return Task.FromResult<object>(null);
            }
            var audience = AudienceStore.FindAudience(clientId);
            if (audience == null || clientSecret != audience.Secret)
            {
                context.SetError("invalid_clientId", $"Invalid Client ID {clientId}");
                return Task.FromResult<object>(null);
            }
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {"*"});
            try
            {
                using (var userManager = new UserManager<User>(new UserStore<User>(new ElearningDbContext())))
                {
                    var user = await userManager.FindAsync(context.UserName, context.Password);
                    if (user == null)
                    {
                        context.SetError("invaild_grant", "The user name or password is incorrect");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                var a = ex;
                throw;
            }
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                {
                    "audience", context.ClientId ?? string.Empty
                }
            });
            var ticket = new AuthenticationTicket(identity, properties);
            context.Validated(ticket);
        }
    }
}