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
    public class PATENTsController : Controller
    {
        private Entities db = new Entities();

        // GET: PATENTs
        public ActionResult Index()
        {
            var pATENT = db.PATENT.Include(p => p.CLASSIFICATION).Include(p => p.COMPANY).Include(p => p.COMPANY1).Include(p => p.PERSON).Include(p => p.PROVINCE);
            return View(pATENT.ToList());
        }

        // GET: PATENTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATENT pATENT = db.PATENT.Find(id);
            if (pATENT == null)
            {
                return HttpNotFound();
            }
            return View(pATENT);
        }

        // GET: PATENTs/Create
        public ActionResult Create()
        {
            ViewBag.CLASS_CODE = new SelectList(db.CLASSIFICATION, "CODE", "SEC_TITLE");
            ViewBag.PATENTEE_NAME = new SelectList(db.COMPANY, "NAME", "ADDRESS");
            ViewBag.PROPOSER_NAME = new SelectList(db.COMPANY, "NAME", "ADDRESS");
            ViewBag.DESIGNER_ID = new SelectList(db.PERSON, "ID", "NAME");
            ViewBag.PLACE_CODE = new SelectList(db.PROVINCE, "CODE", "NAME");
            return View();
        }

        // POST: PATENTs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "APP_NUM,NAME,PATENT_TYPE,CLASS_CODE,DESIGNER_ID,PATENTEE_NAME,PROPOSER_NAME,PLACE_CODE,APP_DATE,PUBLIC_NUM,ABSTRACT,MAIN_CLAIM,CLAIM,AGE,IS_VALID,LINK")] PATENT pATENT)
        {
            if (ModelState.IsValid)
            {
                db.PATENT.Add(pATENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLASS_CODE = new SelectList(db.CLASSIFICATION, "CODE", "SEC_TITLE", pATENT.CLASS_CODE);
            ViewBag.PATENTEE_NAME = new SelectList(db.COMPANY, "NAME", "ADDRESS", pATENT.PATENTEE_NAME);
            ViewBag.PROPOSER_NAME = new SelectList(db.COMPANY, "NAME", "ADDRESS", pATENT.PROPOSER_NAME);
            ViewBag.DESIGNER_ID = new SelectList(db.PERSON, "ID", "NAME", pATENT.DESIGNER_ID);
            ViewBag.PLACE_CODE = new SelectList(db.PROVINCE, "CODE", "NAME", pATENT.PLACE_CODE);
            return View(pATENT);
        }

        // GET: PATENTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATENT pATENT = db.PATENT.Find(id);
            if (pATENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLASS_CODE = new SelectList(db.CLASSIFICATION, "CODE", "SEC_TITLE", pATENT.CLASS_CODE);
            ViewBag.PATENTEE_NAME = new SelectList(db.COMPANY, "NAME", "ADDRESS", pATENT.PATENTEE_NAME);
            ViewBag.PROPOSER_NAME = new SelectList(db.COMPANY, "NAME", "ADDRESS", pATENT.PROPOSER_NAME);
            ViewBag.DESIGNER_ID = new SelectList(db.PERSON, "ID", "NAME", pATENT.DESIGNER_ID);
            ViewBag.PLACE_CODE = new SelectList(db.PROVINCE, "CODE", "NAME", pATENT.PLACE_CODE);
            return View(pATENT);
        }

        // POST: PATENTs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "APP_NUM,NAME,PATENT_TYPE,CLASS_CODE,DESIGNER_ID,PATENTEE_NAME,PROPOSER_NAME,PLACE_CODE,APP_DATE,PUBLIC_NUM,ABSTRACT,MAIN_CLAIM,CLAIM,AGE,IS_VALID,LINK")] PATENT pATENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pATENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLASS_CODE = new SelectList(db.CLASSIFICATION, "CODE", "SEC_TITLE", pATENT.CLASS_CODE);
            ViewBag.PATENTEE_NAME = new SelectList(db.COMPANY, "NAME", "ADDRESS", pATENT.PATENTEE_NAME);
            ViewBag.PROPOSER_NAME = new SelectList(db.COMPANY, "NAME", "ADDRESS", pATENT.PROPOSER_NAME);
            ViewBag.DESIGNER_ID = new SelectList(db.PERSON, "ID", "NAME", pATENT.DESIGNER_ID);
            ViewBag.PLACE_CODE = new SelectList(db.PROVINCE, "CODE", "NAME", pATENT.PLACE_CODE);
            return View(pATENT);
        }

        // GET: PATENTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATENT pATENT = db.PATENT.Find(id);
            if (pATENT == null)
            {
                return HttpNotFound();
            }
            return View(pATENT);
        }

        // POST: PATENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PATENT pATENT = db.PATENT.Find(id);
            db.PATENT.Remove(pATENT);
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
