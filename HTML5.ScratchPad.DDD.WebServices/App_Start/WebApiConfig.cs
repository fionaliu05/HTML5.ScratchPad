using HTML5.ScratchPad.DDD.WebServices.Cors;
using HTML5.ScratchPad.DDD.WebServices.Cors.Handlers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HTML5.ScratchPad.DDD.WebServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.ApplyTo(
                 //ConfigureAuth,
                 ConfigureCors,
                 //ConfigureFilters,
                 //ConfigureFormatters,
                 ConfigureRoutes
             );
        }

        private static void ConfigureCors(HttpConfiguration config)
        {
            //config.EnableCors();
            var corsConfig = new EnableCorsAttribute(AppCorsConstants.AllowedOrigins, AppCorsConstants.AllowedHeaders, AppCorsConstants.AllowedMethods);
            config.EnableCors(corsConfig);

            // Add handler to deal with preflight requests, this is the important part
            config.MessageHandlers.Add(new CorsHandler());
        }

        private static void ConfigureRoutes(HttpConfiguration config)
        {
            // Web API routes

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void ApplyTo<T>(this T source, params System.Action<T>[] targets)
        {
            foreach (var target in targets)
            {
                target(source);
            }
        }
    }
}
