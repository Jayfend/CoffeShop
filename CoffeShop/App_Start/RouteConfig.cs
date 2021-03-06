using System;
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
              name: "Bill",
              url: "Bill",
              defaults: new { controller = "Bill", action = "Index" }
          );

            routes.MapRoute(
               name: "Payment",
               url: "Payment/{action}",
               defaults: new { controller = "Payment" }
           );

            routes.MapRoute(
                name: "Payment_default",
                url: "Payment",
                defaults: new { controller = "Payment", action = "Index" }
            );

            routes.MapRoute(
                name: "Base",
                url: "Base",
                defaults: new { controller = "Base", action = "Change" }
            );

            routes.MapRoute(
                name: "Login",
                url: "Login/{action}",
                defaults: new { controller = "Login" }
            );

            routes.MapRoute(
                name: "Login_default",
                url: "Login",
                defaults: new { controller = "Login", action = "Index" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "Cart/{action}",
                defaults: new { controller = "Cart", action = "Index" }
            );

            routes.MapRoute(
               name: "Cart_default",
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
                url: "Contact/{action}",
                defaults: new { controller = "Contact" }

            );

            routes.MapRoute(
                name: "Contact_default",
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
                url: "Menu/{action}",
                defaults: new { controller = "Menu", action = "Index" }
            );

            routes.MapRoute(
                name: "Menu_wCategory",
                url: "Menu/{categoryId}",
                defaults: new { controller = "Menu", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
