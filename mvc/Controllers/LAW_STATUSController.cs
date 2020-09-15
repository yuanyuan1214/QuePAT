using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using QuePAT.Models;

namespace QuePAT.Controllers
{
    public class LAW_STATUSController : Controller
    {
        private Entities db = new Entities();

        // get law status of app_num, ordered by announce date decending.
        public IQueryable<LAW_STATUS> getLawStatus(string app_num)
        {
            IQueryable<LAW_STATUS> lAW_STATUS = db.LAW_STATUS.Where(l => l.APP_NUM == app_num)
                .OrderByDescending(l => l.ANNOUNCE_DATE);
            return lAW_STATUS;
        }

        // get law status of app_num, ordered by announce date decending.
        public ActionResult GetLawStatus(string app_num)
        {
            IQueryable<LAW_STATUS> lAW_STATUS = db.LAW_STATUS.Where(l => l.APP_NUM == app_num)
                .OrderByDescending(l => l.ANNOUNCE_DATE);
            return Json(lAW_STATUS.ToList());
        }

        // get newest law status of app_num.
        public LAW_STATUS getNewestLawStatus(string app_num)
        {
            LAW_STATUS lAW_STATUS = getLawStatus(app_num).FirstOrDefault();
            return lAW_STATUS;
        }

        // get newest law status of app_num.
        public ActionResult GetNewestLawStatus(string app_num)
        {
            LAW_STATUS lAW_STATUS = getLawStatus(app_num).FirstOrDefault();
            return Json(lAW_STATUS);
        }

        // get current laws status number, may be null.
        //public ActionResult GetCurrentLawStatus(string app_num)
        //{
        //    LAW_STATUS lAW_STATUS = getNewestLawStatus(app_num);
        //    DateTime? date = lAW_STATUS.DUE_DATE;
        //    if (date.HasValue && date.Value.Date <= DateTime.Now.Date)
        //    {
        //        return Json(lAW_STATUS);
        //    }
        //    return Json(new LAW_STATUS());
        //}

        // GET: LAW_STATUS
        public ActionResult Index()
        {
            var lAW_STATUS = db.LAW_STATUS.Include(l => l.PATENT);
            return View(lAW_STATUS.ToList());
        }

        // GET: LAW_STATUS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LAW_STATUS lAW_STATUS = db.LAW_STATUS.Find(id);
            if (lAW_STATUS == null)
            {
                return HttpNotFound();
            }
            return View(lAW_STATUS);
        }

        // GET: LAW_STATUS/Create
        public ActionResult Create()
        {
            ViewBag.APP_NUM = new SelectList(db.PATENT, "APP_NUM", "NAME");
            return View();
        }

        // POST: LAW_STATUS/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "APP_NUM,ANNOUNCE_DATE,DUE_DATE,STATUS,MSG,DETAIL")] LAW_STATUS lAW_STATUS)
        {
            if (ModelState.IsValid)
            {
                db.LAW_STATUS.Add(lAW_STATUS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.APP_NUM = new SelectList(db.PATENT, "APP_NUM", "NAME", lAW_STATUS.APP_NUM);
            return View(lAW_STATUS);
        }

        // GET: LAW_STATUS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LAW_STATUS lAW_STATUS = db.LAW_STATUS.Find(id);
            if (lAW_STATUS == null)
            {
                return HttpNotFound();
            }
            ViewBag.APP_NUM = new SelectList(db.PATENT, "APP_NUM", "NAME", lAW_STATUS.APP_NUM);
            return View(lAW_STATUS);
        }

        // POST: LAW_STATUS/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "APP_NUM,ANNOUNCE_DATE,DUE_DATE,STATUS,MSG,DETAIL")] LAW_STATUS lAW_STATUS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lAW_STATUS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.APP_NUM = new SelectList(db.PATENT, "APP_NUM", "NAME", lAW_STATUS.APP_NUM);
            return View(lAW_STATUS);
        }

        // GET: LAW_STATUS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LAW_STATUS lAW_STATUS = db.LAW_STATUS.Find(id);
            if (lAW_STATUS == null)
            {
                return HttpNotFound();
            }
            return View(lAW_STATUS);
        }

        // POST: LAW_STATUS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LAW_STATUS lAW_STATUS = db.LAW_STATUS.Find(id);
            db.LAW_STATUS.Remove(lAW_STATUS);
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
