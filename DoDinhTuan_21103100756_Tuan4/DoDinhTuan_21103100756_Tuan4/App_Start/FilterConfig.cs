using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_Tuan4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
