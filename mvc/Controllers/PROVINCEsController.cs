using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuePAT.Models;

namespace QuePAT.Controllers
{
    public class PROVINCEsController : Controller
    {
        private Entities db = new Entities();

        // GET: PROVINCEs
        public ActionResult Index()
        {
            return View(db.PROVINCE.ToList());
        }

        // GET: PROVINCEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVINCE pROVINCE = db.PROVINCE.Find(id);
            if (pROVINCE == null)
            {
                return HttpNotFound();
            }
            return View(pROVINCE);
        }

        // GET: PROVINCEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PROVINCEs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODE,NAME")] PROVINCE pROVINCE)
        {
            if (ModelState.IsValid)
            {
                db.PROVINCE.Add(pROVINCE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pROVINCE);
        }

        // GET: PROVINCEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVINCE pROVINCE = db.PROVINCE.Find(id);
            if (pROVINCE == null)
            {
                return HttpNotFound();
            }
            return View(pROVINCE);
        }

        // POST: PROVINCEs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODE,NAME")] PROVINCE pROVINCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROVINCE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pROVINCE);
        }

        // GET: PROVINCEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVINCE pROVINCE = db.PROVINCE.Find(id);
            if (pROVINCE == null)
            {
                return HttpNotFound();
            }
            return View(pROVINCE);
        }

        // POST: PROVINCEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PROVINCE pROVINCE = db.PROVINCE.Find(id);
            db.PROVINCE.Remove(pROVINCE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
