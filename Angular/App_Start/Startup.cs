using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace Angular
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling= PreserveReferencesHandling.Objects;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver=new CamelCasePropertyNamesContractResolver();

            OAuthAuthorizationServerOptions oAuthSerrverOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthAuthorztionServerProvider()
            };

            WebApiConfig.Register(config);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}