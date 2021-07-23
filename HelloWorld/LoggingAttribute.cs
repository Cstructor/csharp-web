using System.Diagnostics;
using System.Web.Mvc;

namespace HelloWorld
{
    public class LoggingAttribute : ActionFilterAttribute
    {
        private Stopwatch stopwatch;

        // Called by the ASP.NET MVC framework BEFORE the action method executes.
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentRequest = filterContext.HttpContext.Request;

            stopwatch = System.Diagnostics.Stopwatch.StartNew();

            base.OnActionExecuting(filterContext);
        }

        // Called by the ASP.NET MVC framework AFTER the action method executes.
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var currentResponse = filterContext.HttpContext.Response;

            stopwatch.Stop();
            var milliseconds = stopwatch.ElapsedMilliseconds;

            System.IO.File.AppendAllText(System.Web.HttpContext.Current.Server.MapPath("~/Logger.txt"),
                string.Format("{0} : Elapsed={1} : Action={2}\n", System.DateTime.Now, stopwatch.Elapsed,
                            filterContext.ActionDescriptor.ActionName));

            base.OnActionExecuted(filterContext);
        }
    }
}