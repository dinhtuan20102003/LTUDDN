using System.Web;
using System.Web.Mvc;

namespace _27_LTUDDN_DoDinhTuan
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
