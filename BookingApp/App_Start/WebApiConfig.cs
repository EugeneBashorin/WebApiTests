using BookingApp.Util;
using System.Web.Http;
using System.Web.Http.Routing.Constraints;

namespace BookingApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "BookRoute",
               routeTemplate: "api/{controller}/{action}/{id}/{name}/{price}/{authorid}/{authorname}/{year}"
               );

            //config.Routes.MapHttpRoute(
            //    name: "BookRoute",
            //    routeTemplate: "api/{controller}/{action}/{id}/{name}/{price}"
            //    );

            config.Routes.MapHttpRoute(
                name:"TwoParamRoute",
                routeTemplate:"api/{controller}/{action}/{num1}/{num2}"
                );


            config.Routes.MapHttpRoute(
              name: "ActionRoute",
              routeTemplate: "api/{controller}/{action}",
              defaults: new { },
              constraints: new
              {
                  action = new AlphaRouteConstraint(),
                  myConstraint = new CustomConstraint("/api/value/get")
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

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // отключаем возможность вывода данных в формате xml
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
