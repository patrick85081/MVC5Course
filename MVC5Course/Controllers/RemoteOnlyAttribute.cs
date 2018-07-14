using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class RemoteOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsLocal)
                filterContext.Result = new RedirectResult("/");

            base.OnActionExecuting(filterContext);
        }
    }
}