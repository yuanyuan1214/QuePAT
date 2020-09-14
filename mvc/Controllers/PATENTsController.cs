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

        // Find patent with name containing string str.
        public IQueryable<PATENT> FindByNameContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.NAME.Contains(str))
                .Include(p => p.CLASSIFICATION)
                .Include(p => p.COMPANY)
                .Include(p => p.COMPANY1)
                .Include(p => p.PERSON)
                .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent by apply number.
        public IQueryable<PATENT> FindByApplyNumber(string app_num)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.APP_NUM.Equals(app_num))
                .Include(p => p.CLASSIFICATION)
                .Include(p => p.COMPANY)
                .Include(p => p.COMPANY1)
                .Include(p => p.PERSON)
                .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent by classification code.
        public IQueryable<PATENT> FindByClassCode(string code)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.CLASS_CODE.Equals(code))
                    .Include(p => p.CLASSIFICATION)
                    .Include(p => p.COMPANY)
                    .Include(p => p.COMPANY1)
                    .Include(p => p.PERSON)
                    .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent by designer name.
        public IQueryable<PATENT> FindByDesignerName(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PERSON.NAME.Equals(name))
                    .Include(p => p.CLASSIFICATION)
                    .Include(p => p.COMPANY)
                    .Include(p => p.COMPANY1)
                    .Include(p => p.PERSON)
                    .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent by patentee name.
        public IQueryable<PATENT> FindByPatenteeName(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PATENTEE_NAME.Equals(name))
                    .Include(p => p.CLASSIFICATION)
                    .Include(p => p.COMPANY)
                    .Include(p => p.COMPANY1)
                    .Include(p => p.PERSON)
                    .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent with patentee name containing str.
        public IQueryable<PATENT> FindByPatenteeNameContains(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PATENTEE_NAME.Contains(name))
                    .Include(p => p.CLASSIFICATION)
                    .Include(p => p.COMPANY)
                    .Include(p => p.COMPANY1)
                    .Include(p => p.PERSON)
                    .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent by proposer name.
        public IQueryable<PATENT> FindByProposerName(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PROPOSER_NAME.Equals(name))
                    .Include(p => p.CLASSIFICATION)
                    .Include(p => p.COMPANY)
                    .Include(p => p.COMPANY1)
                    .Include(p => p.PERSON)
                    .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent with proposer name containing str.
        public IQueryable<PATENT> FindByProposerNameContains(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PROPOSER_NAME.Contains(name))
                    .Include(p => p.CLASSIFICATION)
                    .Include(p => p.COMPANY)
                    .Include(p => p.COMPANY1)
                    .Include(p => p.PERSON)
                    .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent by province code.
        public IQueryable<PATENT> FindByProvinceCode(string code)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PLACE_CODE.Equals(code))
                    .Include(p => p.CLASSIFICATION)
                    .Include(p => p.COMPANY)
                    .Include(p => p.COMPANY1)
                    .Include(p => p.PERSON)
                    .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent by province name.
        public IQueryable<PATENT> FindByProvinceName(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PROVINCE.NAME.Equals(name))
                    .Include(p => p.CLASSIFICATION)
                    .Include(p => p.COMPANY)
                    .Include(p => p.COMPANY1)
                    .Include(p => p.PERSON)
                    .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent by apply date.
        public IQueryable<PATENT> FindByApplyDate(DateTime date)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.APP_DATE.Date.Equals(date.Date))
                    .Include(p => p.CLASSIFICATION)
                    .Include(p => p.COMPANY)
                    .Include(p => p.COMPANY1)
                    .Include(p => p.PERSON)
                    .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent by abstract containing str.
        public IQueryable<PATENT> FindByAbstractContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.ABSTRACT.Contains(str))
                    .Include(p => p.CLASSIFICATION)
                    .Include(p => p.COMPANY)
                    .Include(p => p.COMPANY1)
                    .Include(p => p.PERSON)
                    .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent with main claim containing str.
        public IQueryable<PATENT> FindByMainClaimContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.MAIN_CLAIM.Contains(str))
                    .Include(p => p.CLASSIFICATION)
                    .Include(p => p.COMPANY)
                    .Include(p => p.COMPANY1)
                    .Include(p => p.PERSON)
                    .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent with claim containing str.
        public IQueryable<PATENT> FindByClaimContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.CLAIM.Contains(str))
                    .Include(p => p.CLASSIFICATION)
                    .Include(p => p.COMPANY)
                    .Include(p => p.COMPANY1)
                    .Include(p => p.PERSON)
                    .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent by keyword (name + abstract).
        public IQueryable<PATENT> FindByKeyword(string str)
        {
            return FindByNameContains(str).Union(FindByAbstractContains(str));
        }

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
