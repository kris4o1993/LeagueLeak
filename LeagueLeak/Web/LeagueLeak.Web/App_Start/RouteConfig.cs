using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LeagueLeak.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Display player",
                url: "player/{name}",
                defaults: new { controller = "Players", action = "Display" }
             );

            routes.MapRoute(
                name: "Display article",
                url: "articles/{id}/{url}",
                defaults: new { controller = "Articles", action = "Display" }
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "LeagueLeak.Web.Controllers" }
            );
        }
    }
}
