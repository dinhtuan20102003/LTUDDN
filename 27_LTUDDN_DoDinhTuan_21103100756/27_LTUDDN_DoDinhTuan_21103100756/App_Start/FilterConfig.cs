using System.Web;
using System.Web.Mvc;

namespace _27_LTUDDN_DoDinhTuan_21103100756
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
