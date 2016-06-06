using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Adventure.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //name: "AboutEdit",
            //url: "Home/About",
            //defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //name: "EventsCourses",
            //url: "Home/About",
            //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //name: "EventsSpeakers",
            //url: "Home/Search",
            //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
