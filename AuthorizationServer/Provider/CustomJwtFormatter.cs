using System;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Thinktecture.IdentityModel.Tokens;

namespace AuthorizationServer
{
    internal class CustomJwtFormatter : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string _issuer;
        private const string AudiencePropertyKey = "audience";

        public CustomJwtFormatter(string issuer)
        {
            _issuer = issuer;
        }

        public string Protect(AuthenticationTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentException("ticket");
            }
            var audienceId = ticket.Properties.Dictionary.ContainsKey(AudiencePropertyKey)
                ? ticket.Properties.Dictionary[AudiencePropertyKey]
                : null;
            if (string.IsNullOrWhiteSpace(audienceId))
            {
                throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience");
            }
            var audience = AudienceStore.FindAudience(audienceId);
            var symmetricKeyAsBase64 = audience.Base64Secret;
            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);
            var signingKey = new HmacSigningCredentials(keyByteArray);
            var issued = ticket.Properties.IssuedUtc;
            var expires = ticket.Properties.ExpiresUtc;
            var token = new JwtSecurityToken(_issuer, audienceId, ticket.Identity.Claims, issued?.UtcDateTime, expires?.UtcDateTime, signingKey);
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.WriteToken(token);
            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}