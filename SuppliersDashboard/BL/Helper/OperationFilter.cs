using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoposERB.Helper
{
    public class OperationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

          //  if ((HttpContext.Current.
          //
          //
          //  ["Functions"] as List<Models.Function>).Where(x => x.FunctionName == "operation Page").FirstOrDefault() == null)
            if (Coookie.GetFunctions().Where(x => x.FunctionName == "operation Page").FirstOrDefault() == null)
            {
                filterContext.Result = new RedirectResult("~/Registration/Logout");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}