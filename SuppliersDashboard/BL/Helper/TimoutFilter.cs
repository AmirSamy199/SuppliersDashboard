using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoposERB.Helper
{
    public class TimoutFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CookieModel m = Coookie.Get();
            if(m == null)
            {
                filterContext.Result = new RedirectResult("~/Account/LogIn");

            }


          
           
            base.OnActionExecuting(filterContext);
        }
    }
}