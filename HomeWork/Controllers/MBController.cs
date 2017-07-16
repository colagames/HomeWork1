using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomEdit(int id)
        {
     
            return View(repo.Find(id));
        }

        [HttpPost]
        public ActionResult CustomEdit(int id,客戶資料 data)
        {
            var l_data = repo.Find(id);

            return Json(l_data);
        }

    }
}