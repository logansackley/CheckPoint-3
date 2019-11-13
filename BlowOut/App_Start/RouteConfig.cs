﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlowOut
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "Contact",
             url: "{Controller}/",
             defaults: new { controller = "Contact", action = "Index"}
         );


            routes.MapRoute(
               name: "Email",
               url: "{Controller}/{action}/{name}/{email}",
               defaults: new { controller = "Contact", action = "Email", name = UrlParameter.Optional, email =  UrlParameter.Optional}
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
