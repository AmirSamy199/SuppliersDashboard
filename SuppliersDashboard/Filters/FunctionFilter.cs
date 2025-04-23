
using SuppliersDashboard.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SuppliersDashboard.Filters
{
    public class FunctionFilter :  ActionFilterAttribute
    {
        public string key { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        List<string> userFunctions = Cokie.UserFunctionsGet();
        if (!userFunctions.Contains(key))
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                                {"Controller","Home" },
                                {"Action","AccessDenied" }
                 });
        }

    }
}
}