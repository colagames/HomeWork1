using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Attributes
{
    public class CheckKeyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var key = filterContext.HttpContext.Request.QueryString["key"];

            if (key == "222") { filterContext.Result = new RedirectResult("/Home"); return; }

            filterContext.Controller.ViewBag.T1 = "TEST2";

            filterContext.Controller.ViewData["T1"] = "TEST1";
        }


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        
    }
}