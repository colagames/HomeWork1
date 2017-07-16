using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
    public class ARController : BaseController
    {
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult file1()
        {
            return File(Server.MapPath("~/Content/abc.jpg"),"image/jpeg");
        }
        public ActionResult file2()
        {
            return File(Server.MapPath("~/Content/abc.jpg"), "image/jpeg","asdf.jpeg");
        }
        [HttpGet]  
        public ActionResult json1()
        {
            repo.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;
            var data = repo.Find(1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}