using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
    public abstract class BaseController : Controller
    {
        public 客戶資料Repository repo = RepositoryHelper.Get客戶資料Repository();

        //想從Webconfig內抓島404PAGE 但還沒做完
        //protected override void HandleUnknownAction(string actionName)
        //{
        //     Redirect("").ExecuteResult(this.ControllerContext);
        //}
    }
}