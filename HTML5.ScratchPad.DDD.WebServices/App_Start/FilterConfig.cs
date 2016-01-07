using System.Web;
using System.Web.Mvc;

namespace HTML5.ScratchPad.DDD.WebServices
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
