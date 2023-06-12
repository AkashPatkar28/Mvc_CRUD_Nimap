﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc_CRUD_Nimap
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                 //defaults: new { controller = "Class1", action = "Index", id = UrlParameter.Optional }

                 defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}