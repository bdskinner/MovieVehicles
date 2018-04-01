using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieVehicles
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
                name: "Reviews",
                url: "{controller}/{action}/{sortOrder}",
                defaults: new { controller = "Reviews", action = "Index", sortOrder = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Vehicles",
                url: "{controller}/{action}/{searchTitle}/{searchName}/{createdBy}",
                defaults: new { controller = "Reviews", action = "Index", searchTitle = UrlParameter.Optional, searchName = UrlParameter.Optional, createdBy = UrlParameter.Optional }
            );
        }
    }
}
