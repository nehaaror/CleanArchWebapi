using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CrudWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // for declaring globally the exception filter
            config.Filters.Add(new MyExceptionAttribute());
            config.Filters.Add(new ApiKeyAuthorizeAttribute());
            GlobalConfiguration.Configuration.MessageHandlers.Add(new ApiKeyhandler());
        }
    }
}
