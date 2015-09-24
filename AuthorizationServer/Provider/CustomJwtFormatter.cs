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
            if (ticket == null) throw new ArgumentException("ticket");
            var audienceId = ticket.Properties.Dictionary.ContainsKey(AudiencePropertyKey)
                ? ticket.Properties.Dictionary[AudiencePropertyKey]
                : null;
            if (string.IsNullOrWhiteSpace(audienceId))
                throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience");
            var audience = AudienceStore.FindAudience(audienceId);
            var keyByteArray = TextEncodings.Base64Url.Decode(audience.Base64Secret);
            var signingKey = new HmacSigningCredentials(keyByteArray);
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: audienceId,
                claims: ticket.Identity.Claims,
                notBefore: ticket.Properties.IssuedUtc?.UtcDateTime,
                expires: ticket.Properties.ExpiresUtc?.UtcDateTime,
                signingCredentials: signingKey);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}