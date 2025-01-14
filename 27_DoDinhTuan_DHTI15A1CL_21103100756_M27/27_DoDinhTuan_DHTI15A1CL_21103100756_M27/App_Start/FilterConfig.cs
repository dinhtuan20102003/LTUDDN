using System.Web;
using System.Web.Mvc;

namespace _27_DoDinhTuan_DHTI15A1CL_21103100756_M27
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
