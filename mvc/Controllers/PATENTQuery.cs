using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuePAT.Models;
using Newtonsoft.Json;

namespace QuePAT.Controllers
{
    public class PATENTQuery : Controller
    {
        private Entities db = new Entities();

        public IQueryable<PATENT> findByNameContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.NAME.Contains(str));
            return pATENT;
        }

        // Find patent with name containing string str.
        [HttpPost]
        public ActionResult FindByNameContains(string str)
        {
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(findByNameContains(str).ToList())
            };
        }

        // Find patent by apply number.
        public ActionResult FindByApplyNumber(string app_num)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.APP_NUM.Equals(app_num));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList()) };
        }

        // Find patent by classification code.
        public ActionResult FindByClassCode(string code)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.CLASS_CODE.Equals(code));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList()) };
        }

        // Find patent by designer name.
        public ActionResult FindByDesignerName(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PERSON.NAME.Equals(name));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList()) };
        }

        // Find patent by patentee name.
        public ActionResult FindByPatenteeName(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PATENTEE_NAME.Equals(name));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList()) };
        }

        // Find patent with patentee name containing str.
        public ActionResult FindByPatenteeNameContains(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PATENTEE_NAME.Contains(name));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList()) };
        }

        // Find patent by proposer name.
        public ActionResult FindByProposerName(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PROPOSER_NAME.Equals(name));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList()) };
        }

        // Find patent with proposer name containing str.
        public ActionResult FindByProposerNameContains(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PROPOSER_NAME.Contains(name));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList()) };
        }

        // Find patent by province code.
        public ActionResult FindByProvinceCode(string code)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PLACE_CODE.Equals(code));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList()) };
        }

        // Find patent by province name.
        public ActionResult FindByProvinceName(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PROVINCE.NAME.Equals(name));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList()) };
        }

        // Find patent by apply date.
        public ActionResult FindByApplyDate(DateTime date)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.APP_DATE.Date.Equals(date.Date));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList()) };
        }

        public IQueryable<PATENT> findByAbstractContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.ABSTRACT.Contains(str));
            return pATENT;
        }

        // Find patent by abstract containing str.
        public ActionResult FindByAbstractContains(string str)
        {
            return new ContentResult { Content = JsonConvert.SerializeObject(findByAbstractContains(str).ToList()) };
        }

        // Find patent with main claim containing str.
        public ActionResult FindByMainClaimContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.MAIN_CLAIM.Contains(str));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList()) };
        }

        // Find patent with claim containing str.
        public ActionResult FindByClaimContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.CLAIM.Contains(str));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList()) };
        }

        // Find patent by keyword (name + abstract).
        public ActionResult FindByKeyword(string str)
        {
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject
                (
                    findByNameContains(str).
                    Union(findByAbstractContains(str)).
                    ToList()
                )
            };
        }

        // Find number of patents proposed by a company in a specific year.
        public ActionResult PatentNumInYear(string company_name, int year)
        {
            return Content(
                db.PATENT
                .Where(
                    p => p.PROPOSER_NAME.Equals(company_name)
                    && p.APP_DATE.Year.Equals(year)
                )
                .Count()
                .ToString()
                );
        }

        public ActionResult PatentNumOfType(string company_name, string class_code)
        {
            return Content(
                db.PATENT
                .Where
                (
                    p => p.PROPOSER_NAME.Equals(company_name)
                    && p.CLASS_CODE.Equals(class_code)
                )
                .Count()
                .ToString()
                );
        }

    }
}