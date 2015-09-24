using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.OAuthBearer;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApplication.ResourceServer
{
    public class Startup
    {
        const string _TokenIssuer = "contoso.com";
        const string _TokenAudience = "contoso.com/resources";
        RsaSecurityKey _key = null;
        SigningCredentials _signingCredentials = null;

        public Startup(IHostingEnvironment env)
        {
            GenerateRsaKeys();
        }

        private void GenerateRsaKeys()
        {
            var key = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw";
            var keyByte = TextEncodings.Base64Url.Decode(key);
            var symmetricSecurityKey = new SymmetricSecurityKey(keyByte);
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                _key = new RsaSecurityKey(rsa.ExportParameters(true));

                _signingCredentials = new SigningCredentials(
                    symmetricSecurityKey,
                    SecurityAlgorithms.HmacSha256Signature,
                    SecurityAlgorithms.Sha256Digest,
                    "secret");

                rsa.PersistKeyInCsp = false;
            }
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInstance(_signingCredentials);

            services.AddMvc(options =>
            {
                options.Filters.Add(new GlobalExceptionHandler());
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            });

            services.ConfigureOAuthBearerAuthentication(options =>
            {
                options.AutomaticAuthentication = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = _key,
                    ValidAudience = _TokenAudience,
                    ValidIssuer = _TokenIssuer
                };
            });

            services.ConfigureAuthorization(options =>
            {
                options.AddPolicy(
                    "Bearer",
                    new AuthorizationPolicyBuilder().
                        AddAuthenticationSchemes(OAuthBearerAuthenticationDefaults.AuthenticationScheme).
                        RequireAuthenticatedUser().
                        Build());
            });
            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            app.UseOAuthBearerAuthentication();

            // Add MVC to the request pipeline.
            app.UseMvc();
            // Add the following route for porting Web API 2 controllers.
            // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
        }
    }

    public class GlobalExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
        }
    }
}
