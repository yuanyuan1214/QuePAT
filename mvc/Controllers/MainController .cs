using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Microsoft.Ajax.Utilities;
using QuePAT.Models;


namespace QuePAT.Controllers
{
    public class MainController : Controller
    {
        private Entities db = new Entities();

        public IQueryable<PATENT> findByNameContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.NAME.Contains(str))
                .Include(p => p.CLASSIFICATION)
                .Include(p => p.COMPANY)
                .Include(p => p.COMPANY1)
                .Include(p => p.PERSON)
                .Include(p => p.PROVINCE);
            return pATENT;
        }

        // Find patent with name containing string str.
        public ActionResult FindByNameContains(string str)
        {
            return Json(findByNameContains(str).ToList());
        }

        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string keyword)
        {
            //var data = SearchVideoDB(keyword);
            //Json root = new Json();
            //root["patent_name"] = new JsonData();
            var data = FindByNameContains(keyword);

            return data;
        }
        public ActionResult SearchResult()
        {
            return View();
        }

    }
}