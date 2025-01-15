using DoDinhTuan_21103100756_DHTI15A1CL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoDinhTuan_21103100756_DHTI15A1CL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Giaipt",
                url: "{controller}/{action}/{a}/{b}/{c}"
           
                );
            routes.MapRoute(
              name: "UCLN",
              url: "{controller}/{action}/{a}/{b}"

              );
        }
    }
}
