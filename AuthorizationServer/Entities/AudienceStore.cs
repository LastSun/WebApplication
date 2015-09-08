using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using Microsoft.Owin.Security.DataHandler.Encoder;

namespace AuthorizationServer
{
    public class AudienceStore
    {
        public static ConcurrentDictionary<string,Audience> Audiences=new ConcurrentDictionary<string, Audience>();

        static AudienceStore()
        {
            Audiences.TryAdd("ClientId", new Audience
            {
                Id = "ClientId",
                Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw",
                Name = "ClientName"
            });
        }

        public static Audience AddAudience(string name)
        {
            var clientId = Guid.NewGuid().ToString();
            var key = new byte[32];
            RandomNumberGenerator.Create().GetBytes(key);
            var base64Secret = TextEncodings.Base64Url.Encode(key);
            var newAudience = new Audience {Id = clientId, Base64Secret = base64Secret, Name = name};
            Audiences.TryAdd(clientId, newAudience);
            return newAudience;
        }

        public static Audience FindAudience(string clientId)
        {
            Audience audience;
            Audiences.TryGetValue(clientId, out audience);
            return audience;
        }
    }
}