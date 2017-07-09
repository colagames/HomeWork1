using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
    public class DetailController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();
        public ActionResult Index()
        {
            var 客製檢視表 = db.客製檢視表.ToList();
            return View(客製檢視表);
        }
    }
}