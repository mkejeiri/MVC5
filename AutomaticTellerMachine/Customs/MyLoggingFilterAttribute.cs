using System.Web;
using System.Web.Mvc;

namespace AutomaticTellerMachine.Customs
{
    public class MyLoggingFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpRequestBase request = filterContext.HttpContext.Request;
            Logger.logRequest(request.UserHostAddress);
            base.OnActionExecuted(filterContext);
        }
    }

    public class Logger {
        public static void logRequest(string p)
        {
           //Todo
        }
    }
}