using DoDinhTuan_21103100756_LTUDDN_BTVN_TUAN6.App_Start;
using DoDinhTuan_21103100756_LTUDDN_BTVN_TUAN6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DoDinhTuan_21103100756_LTUDDN_BTVN_TUAN6
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new MyDB());
        }
    }
}
