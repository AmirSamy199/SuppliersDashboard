using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoposERB.Helper
{
    public class BanksFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Coookie.GetFunctions().Where(x => x.FunctionName == "Banks Page").FirstOrDefault() == null)
            {
                filterContext.Result = new RedirectResult("~/Registration/Logout");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}