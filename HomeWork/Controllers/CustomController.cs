using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
    public class CustomController : Controller
    {

        客戶資料Repository repo = RepositoryHelper.Get客戶資料Repository();

  
        public ActionResult Index()
        {
            var data = repo.get前10筆資料();
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(string keyword)
        {
            var data = repo.FindByKeyWord(keyword);
            return View(data);
        }

        public ActionResult Create()
        {    
            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶資料 p_data)
        {
            if (ModelState.IsValid)
            {
                repo.Add(p_data);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Delete(int? Id)
        {
            客戶資料 l_data = repo.Find(Id.Value);
            repo.Delete(l_data);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 l_data = repo.Find(Id.Value);
            if (l_data == null)
            {
                return HttpNotFound();
            }
            return View(l_data);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( 客戶資料 product)
        {
            if (ModelState.IsValid)
            {
                var db = repo.UnitOfWork.Context;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}