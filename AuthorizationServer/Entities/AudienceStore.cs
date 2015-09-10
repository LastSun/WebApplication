using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using Microsoft.Owin.Security.DataHandler.Encoder;

namespace AuthorizationServer
{
    public class AudienceStore
    {
        public static ConcurrentDictionary<string, Audience> Audiences = new ConcurrentDictionary<string, Audience>();

        static AudienceStore()
        {
            Audiences.TryAdd("EBFFA96E-D737-4FCF-B115-AF452179D62F", new Audience
            {
                Id = "EBFFA96E-D737-4FCF-B115-AF452179D62F",
                Secret = "Heyker",
                Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw"
            });
        }

        public static Audience FindAudience(string clientId)
        {
            Audience audience;
            Audiences.TryGetValue(clientId, out audience);
            return audience;
        }

        public static Audience AddAudience()
        {
            var clientId = Guid.NewGuid().ToString().ToUpper();

            var key = new byte[32];
            RandomNumberGenerator.Create().GetBytes(key);
            var base64Secret = TextEncodings.Base64Url.Encode(key);

            var newAudience = new Audience {Id = clientId, Secret = "Heyker", Base64Secret = base64Secret};
            Audiences.TryAdd(clientId, newAudience);
            return newAudience;
        }
    }
}