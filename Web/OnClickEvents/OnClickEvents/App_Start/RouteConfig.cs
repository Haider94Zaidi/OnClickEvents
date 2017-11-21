using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnClickEvents
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "register",
                url: "{controller}/{action}",
                defaults: new { controller = "Registration", action = "Register"}
            );

            routes.MapRoute(
                name: "registering",
                url: "{controller}/{action}",
                defaults: new { controller = "Registration", action = "Registering" }
            );

            routes.MapRoute(
                name:"signin",
                url:"{controller}/{action}",
                defaults: new { controller = "Registration", action = "SignIn" }
            );

            routes.MapRoute(
                name:"user",
                url:"{controller}/{action}",
                defaults: new { controller = "User" , action="HomePage" }
                );
            routes.MapRoute(
                name:"admindashboard",
                url:"{controller}/{action}",
                defaults:new { controller="Vendor",action="DashBoard" } 
                );
            

        }
    }
}
