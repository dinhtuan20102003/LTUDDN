using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoDinhTuan_21103100756_LTUDDN
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
                name: "Anh",
                url: "{controller}/{action}/{a}"
            );

            routes.MapRoute(
                name: "TimNgay",
                url: "{controller}/{action}/{thang}/{nam}"
            );

            routes.MapRoute(
                name: "Gptbac2",
                url: "{controller}/{action}/{a}/{b}/{c}"
            );

            routes.MapRoute(
                name: "UCLN",
                url: "{controller}/{action}/{a}/{b}"
            );
        }
    }
}
