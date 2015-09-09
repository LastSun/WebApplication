using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using Microsoft.Owin.Security.DataHandler.Encoder;

namespace AuthorizationServer
{
    public class AudienceStore
    {
        public static string Secret4Default = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw";
        public static string Secret4Web = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw";
        public static ConcurrentDictionary<string, Audience> Audiences = new ConcurrentDictionary<string, Audience>();

        public static Audience FindAudience(string clientId)
        {
            Audience audience;
            Audiences.TryGetValue(clientId, out audience);
            return audience;
        }

        public static Audience AddAudience()
        {
            return AddAudience(Guid.NewGuid().ToString());
        }

        public static Audience AddAudience(string clientId, string clientSecret="")
        {
            string base64Secret;
            switch (clientSecret)
            {
                case "Heyker":
                    base64Secret = Secret4Web;
                    break;
                default:
                    base64Secret = Secret4Default;
                    break;
            }
            var audience = new Audience
            {
                Id = clientId,
                Secret = clientSecret,
                Base64Secret = base64Secret
            };
            Audiences.TryAdd(clientId, audience);
            return audience;
        }
    }
}