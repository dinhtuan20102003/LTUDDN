using System.Web;
using System.Web.Mvc;

namespace _15_LTUDDN_DoDinhTuan_21103100756_15
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
