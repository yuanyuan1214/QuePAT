﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuePAT.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.DynamicData;

namespace QuePAT.Controllers
{
    public class PATENTQuery : Controller
    {
        static JsonSerializerSettings jsSettings = new JsonSerializerSettings();
        private Entities db = new Entities();

        public PATENTQuery()
        {
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

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
                Content = JsonConvert.SerializeObject(findByNameContains(str).ToList(), jsSettings)
            };
        }

        // Find patent by apply number.
        public IQueryable<PATENT> findByApplyNumber(string app_num)
        {
            return db.PATENT.Where(p => p.APP_NUM.Equals(app_num));
        }

        // Find patent by apply number.
        public ActionResult FindByApplyNumber(string app_num)
        {
            PATENT pATENT = db.PATENT.Where(p => p.APP_NUM.Equals(app_num)).FirstOrDefault();
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT, jsSettings) };
        }

        public IQueryable<PATENT> findByClassCode(string code)
        {
            return db.PATENT.Where(p => p.CLASS_CODE.Equals(code));
        }

        // Find patent by classification code.
        public ActionResult FindByClassCode(string code)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.CLASS_CODE.Equals(code));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList(), jsSettings) };
        }

        // Find patent by designer name.
        public IQueryable<PATENT> findByDesignerName(string name)
        {
            return db.PATENT.Where(p => p.PERSON.NAME.Equals(name));
        }

        public ActionResult FindByDesignerName(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PERSON.NAME.Equals(name));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList(), jsSettings) };
        }

        // Find patent by patentee name.
        public ActionResult FindByPatenteeName(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PATENTEE_NAME.Equals(name));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList(), jsSettings) };
        }

        // Find patent with patentee name containing str.
        public IQueryable<PATENT> findByPatenteeNameContains(string name)
        {
            return db.PATENT.Where(p => p.PATENTEE_NAME.Contains(name));
        }

        // Find patent with patentee name containing str.
        public ActionResult FindByPatenteeNameContains(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PATENTEE_NAME.Contains(name));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList(), jsSettings) };
        }

        // Find patent by proposer name.
        public ActionResult FindByProposerName(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PROPOSER_NAME.Equals(name));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList(), jsSettings) };
        }

        // Find patent with proposer name containing str.
        public IQueryable<PATENT> findByProposerNameContains(string name)
        {
            return db.PATENT.Where(p => p.PROPOSER_NAME.Contains(name));
        }

        // Find patent with proposer name containing str.
        public ActionResult FindByProposerNameContains(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PROPOSER_NAME.Contains(name));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList(), jsSettings) };
        }

        // Find patent by province code.
        public IQueryable<PATENT> findByProvinceCode(string code)
        {
            return db.PATENT.Where(p => p.PLACE_CODE.Equals(code));
        }

        // Find patent by province code.
        public ActionResult FindByProvinceCode(string code)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PLACE_CODE.Equals(code));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList(), jsSettings) };
        }

        // Find patent by province name.
        public IQueryable<PATENT> findByProvinceName(string name)
        {
            return db.PATENT.Where(p => p.PROVINCE.NAME.Equals(name));
        }

        // Find patent by province name.
        public ActionResult FindByProvinceName(string name)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.PROVINCE.NAME.Equals(name));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList(), jsSettings) };
        }

        // Find patent by apply date.
        public IQueryable<PATENT> findByApplyDate(DateTime date)
        {
            return db.PATENT.Where(p => p.APP_DATE.Date.Equals(date.Date));
        }

        // Find patent by apply date.
        public ActionResult FindByApplyDate(DateTime date)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.APP_DATE.Date.Equals(date.Date));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList(), jsSettings) };
        }

        public IQueryable<PATENT> findByAbstractContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.ABSTRACT.Contains(str));
            return pATENT;
        }

        // Find patent by abstract containing str.
        public ActionResult FindByAbstractContains(string str)
        {
            return new ContentResult { Content = JsonConvert.SerializeObject(findByAbstractContains(str).ToList(), jsSettings) };
        }

        // Find patent with main claim containing str.
        public ActionResult FindByMainClaimContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.MAIN_CLAIM.Contains(str));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList(), jsSettings) };
        }

        // Find patent with claim containing str.
        public IQueryable<PATENT> findByClaimContains(string str)
        {
            return db.PATENT.Where(p => p.CLAIM.Contains(str));
        }

        // Find patent with claim containing str.
        public ActionResult FindByClaimContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.CLAIM.Contains(str));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENT.ToList(), jsSettings) };
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

        public ActionResult SearchExpert
            (
            string class_code,
            string desinger,
            string app_num,
            string proposer,
            string abst,
            string province,
            string app_date,
            string claim
            )
        {
            IQueryable<PATENT> pATENTs = findByClassCode(class_code)
                .Union(findByDesignerName(desinger))
                .Union(findByApplyNumber(app_num))
                .Union(findByProposerNameContains(proposer))
                .Union(findByAbstractContains(abst))
                .Union(findByProvinceCode(province))
                .Union(findByApplyDate(Convert.ToDateTime(app_date)))
                .Union(findByClaimContains(claim));
            return new ContentResult { Content = JsonConvert.SerializeObject(pATENTs, jsSettings) };
        }

        // Find number of patents proposed by a company in a specific year.
        public ActionResult PatentNumInYear(string company_name)
        {
            var yearPATENT = db.PATENT
                .Where(
                    p => p.PROPOSER_NAME.Equals(company_name)
                )
                .GroupBy(p => p.APP_DATE.Year)
                .Select(p => new { YEAR = p.Key, QUANT = p.Count() });
            return new ContentResult { Content = JsonConvert.SerializeObject(yearPATENT.ToList(), jsSettings) };
        }

        public ActionResult PatentNumOfType(string company_name)
        {
            var typePATENT = db.PATENT
                .Where(
                    p => p.PROPOSER_NAME.Equals(company_name)
                )
                .GroupBy(p => p.CLASS_CODE.ElementAt(0))
                .Select(p => new { YEAR = p.Key, QUANT = p.Count() });
            return new ContentResult { Content = JsonConvert.SerializeObject(typePATENT.ToList(), jsSettings) };
        }
    }
}
