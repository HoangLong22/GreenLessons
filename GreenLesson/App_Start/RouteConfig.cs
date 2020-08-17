using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GreenLesson
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "About",
             url: "gioi-thieu",
             defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "GreenLesson.Controllers" }
         );

            routes.MapRoute(
           name: "Contact",
           url: "lien-he",
           defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
           namespaces: new[] { "GreenLesson.Controllers" }
       );
            routes.MapRoute(
               name: "Login",
               url: "dang-nhap",
               defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
               namespaces: new[] { "GreenLesson.Controllers" }
           );
            routes.MapRoute(
               name: "Register",
               url: "dang-ky",
               defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
               namespaces: new[] { "GreenLesson.Controllers" }
           );

            routes.MapRoute(
              name: "News",
              url: "chi-tiet/{metatitle}-{id}",
              defaults: new { controller = "New", action = "Detail", id = UrlParameter.Optional },
              namespaces: new[] { "GreenLesson.Controllers" }
          );

            routes.MapRoute(
             name: "Lesson",
             url: "bai-giang/{metatitle}-{id}",
             defaults: new { controller = "Lesson", action = "Detail", id = UrlParameter.Optional },
             namespaces: new[] { "GreenLesson.Controllers" }
         );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "GreenLesson.Controllers" }
            );

            routes.MapRoute(
              name: "New",
              url: "{metatitle}/{id}",
              defaults: new { controller = "About", action = "Detail", id = UrlParameter.Optional },
              namespaces: new[] { "GreenLesson.Controllers" }
          );

          
        }
    }
}
