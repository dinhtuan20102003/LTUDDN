﻿using System.Web;
using System.Web.Mvc;

namespace _27_DoDinhTuan_21103100756_DHTI15A1CL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
