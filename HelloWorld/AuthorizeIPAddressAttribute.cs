using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld
{
    public class AuthorizeIPAddressAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentRequest = filterContext.HttpContext.Request;

            if (currentRequest.UserHostAddress == "::1")
            {
                filterContext.Result = new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}