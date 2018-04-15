using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieVehicles.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AuthorizationOrRedirectAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {          
            base.HandleUnauthorizedRequest(filterContext);

            if (filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Error/AccessDenied");
            }
        }
    }
}