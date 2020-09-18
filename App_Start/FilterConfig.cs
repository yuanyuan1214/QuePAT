using System.Web;
using System.Web.Mvc;

namespace Community_Module_of_QuePAT
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
