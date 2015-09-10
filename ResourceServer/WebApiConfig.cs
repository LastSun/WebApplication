using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace ResourceServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            config.Services.Replace(typeof (IExceptionHandler), new GlobalExceptionHandler());
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            //config.Routes.MapHttpRoute(
            //    name: "Error",
            //    routeTemplate: "{*url}",
            //    defaults: new { controller = "Error", action = "Handle" }
            //    );
        }
    }

    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            //new ErrorController().Handle();
            base.Handle(context);
        }
    }
}