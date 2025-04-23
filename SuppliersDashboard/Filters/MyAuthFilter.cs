using SuppliersDashboard.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SuppliersDashboard.Filters
{
    
        public class MyAuthFilter : ActionFilterAttribute
        {
    
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                base.OnActionExecuting(context);

          
            var user = Cokie.UserGet();
            if (user.Id == 0)
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                                {"Controller","Account" },
                                {"Action","LogIn" }
                         });
                    }

             }
        }
      
    
}