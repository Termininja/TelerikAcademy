namespace BullsAndCows.WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Microsoft.Owin.Security.OAuth;
    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Route for the Account
            config.Routes.MapHttpRoute(
                name: "Account",
                routeTemplate: "{api}/{Account}/{action}",
                defaults: new
                {
                    api = RouteParameter.Optional,
                    Account = RouteParameter.Optional,
                    controller = "Account"
                }
            );

            //Route for the games
            config.Routes.MapHttpRoute(
                name: "Games",
                routeTemplate: "api/games/{id}",
                defaults: new { controller = "Games" }
            );

            //Route for the guess
            config.Routes.MapHttpRoute(
                name: "Guess",
                routeTemplate: "api/games/{id}/guess",
                defaults: new { controller = "Guess" }
            );

            //Route for the notifications
            config.Routes.MapHttpRoute(
                name: "Notifications",
                routeTemplate: "api/notifications/{id}",
                defaults: new { controller = "Notifications" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
