using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoposERB.Helper
{
    public class IntegrationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //if ((HttpContext.Current.
            //
            //["Functions"] as List<Models.Function>).Where(x => x.FunctionName == "integration Page").FirstOrDefault() == null)
            if (Coookie.GetFunctions().Where(x => x.FunctionName == "integration Page").FirstOrDefault() == null)
            {
                filterContext.Result = new RedirectResult("~/Account/LogOut");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}