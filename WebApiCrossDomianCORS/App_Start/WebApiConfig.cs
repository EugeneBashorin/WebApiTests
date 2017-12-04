using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing.Constraints;

namespace WebApiCrossDomianCORS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();//Add CORS support

            //var cors = new EnableCorsAttribute("http://www.example.com", "*", "*");   ==>> Add global setting to all controllers(origins*(host)*,headers,metods)
            //config.EnableCors(cors);

            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ActionRoute",
                routeTemplate:"api/{controller}/{action}",
                defaults: new {},
                constraints: new
                {
                    action = new AlphaRouteConstraint()
                }
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {/* id = RouteParameter.Optional */},
                constraints: new
                {
                    id = new IntRouteConstraint()
                }
            );
        }
    }
}
