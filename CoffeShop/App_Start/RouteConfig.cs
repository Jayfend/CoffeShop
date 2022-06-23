﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CoffeShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login_default",
                url: "Login",
                defaults: new { controller = "Login", action = "Index" }
            );

            routes.MapRoute(
                name: "Login",
                url: "Login/{action}",
                defaults: new { controller = "Login", action = "Login" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "Cart",
                defaults: new { controller = "Cart", action = "Index" }
            );

            routes.MapRoute(
                name: "Profile",
                url: "Profile",
                defaults: new { controller = "Profile", action = "Index" }
            );

            routes.MapRoute(
                name: "Contact",
                url: "Contact",
                defaults: new { controller = "Contact", action = "Index" }
            );

            routes.MapRoute(
                name: "TodaySpecials",
                url: "TodaySpecials",
                defaults: new { controller = "TodaySpecials", action = "Index" }
            );

            routes.MapRoute(
                name: "Menu",
                url: "Menu/{categoryID}",
                defaults: new { controller = "Menu", action = "Index"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
           
        }
    }
}
