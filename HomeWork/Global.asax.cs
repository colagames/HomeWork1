using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HomeWork
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

           

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //刪除傳統.Net 刪除 web form 的VIEW，減少VIEW讀取時間
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            //傳統.NET的WEB FORM VIEW
            //ViewEngines.Engines.Add(new WebFormViewEngine());
        }
    }
}
