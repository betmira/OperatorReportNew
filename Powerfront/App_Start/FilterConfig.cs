using Powerfront.Repository;
using System.Web;
using System.Web.Mvc;

namespace Powerfront
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());          
                //Add simple injector resolved types.
             //   filters.Add(container.GetInstance<OperatorReportRepository>());
          
        }
    }
}
