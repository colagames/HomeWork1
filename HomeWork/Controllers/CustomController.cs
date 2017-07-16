using Day2MVCDemo.Models.ViewModels;
using HomeWork.Attributes;
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
    public class CustomController : BaseController
    {
        //丟到BaseController了
        //客戶資料Repository repo = RepositoryHelper.Get客戶資料Repository();

        [CheckKeyAttribute]
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
        [HttpPost]
        public ActionResult BatchUpdate(BatchUpdateVM[] data)
        {
            if (ModelState.IsValid) {

                foreach (var item in data) {

                    var aa = repo.Find(item.Id);
                    aa.傳真 = item.傳真;
                    aa.電話 = item.電話;
                }
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewData.Model = repo.get前10筆資料();
            return View("Index");
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
            //repo.Delete(l_data);
            //repo.UnitOfWork.Commit();
            l_data.是否已刪除 = true;

            if (TryUpdateModel(l_data, new string[] { "是否已刪除" }))
            {
                //var db = repo.UnitOfWork.Context;
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();

                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

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
        public ActionResult Edit( int Id)
        {

            var product = repo.Find(Id);

            if (TryUpdateModel(product,new string[] { "電話", "地址" }))
            {
                //var db = repo.UnitOfWork.Context;
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();

                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}