using System.Web;
using System.Web.Mvc;

namespace NTDCodeChallenge_MVC_CSharp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
