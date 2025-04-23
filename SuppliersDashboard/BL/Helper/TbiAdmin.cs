using ScoposERB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoposERB.Helper
{
    public class TbiAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

             if (Coookie.Get().User.TbiAdmin != 1)
            {
                filterContext.Result = new RedirectResult("~/Registration/Logout");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}