using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using QuePAT.Models;


namespace QuePAT.Controllers
{

    public class MainController : Controller
    {
        private Entities db = new Entities();

        JsonSerializerSettings jsSettings = new JsonSerializerSettings();

        public MainController()
        {
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
        public IQueryable<PATENT> findByNameContains(string str)
        {
            IQueryable<PATENT> pATENT = db.PATENT.Where(p => p.NAME.Contains(str));
            return pATENT;
        }

        // Find patent with name containing string str.
        public ActionResult FindByNameContains(string str)
        {
            if (str == "" || str == null)
            {
                return null;
            }
            string json = JsonConvert.SerializeObject(
                db.PATENT.Where(
                    p => p.NAME.Contains(str)
                    )
                .Select(p => new { APP_NUM = p.APP_NUM, NAME = p.NAME, APP_DATE = p.APP_DATE }
                )
                .ToList(), jsSettings);
            return new ContentResult { Content = json };
        }

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
            string json = JsonConvert.SerializeObject(lAW_STATUS.ToList(), jsSettings);
            return new ContentResult { Content = json };
        }

        public LAW_STATUS getNewestLawStatus(string app_num)
        {
            LAW_STATUS lAW_STATUS = getLawStatus(app_num).FirstOrDefault();
            return lAW_STATUS;
        }

        // get newest law status of app_num.
        public ActionResult GetNewestLawStatus(string app_num)
        {
            LAW_STATUS lAW_STATUS = getNewestLawStatus(app_num);
            string json = JsonConvert.SerializeObject(lAW_STATUS, jsSettings);
            return new ContentResult { Content = json };
        }

        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        /*public ActionResult Search(int type,string keyword)
        {
            //var data = SearchVideoDB(keyword);
            //Json root = new Json();
            //root["patent_name"] = new JsonData();
            if (type == 0) {
                var data = FindByNameContains(w1);
                return data;
            }
            else if (type == 2)
            {
                var data2 = GetNewestLawStatus(w1);
                return data2;
            }
            var da = FindByNameContains(keyword);
            return da;
        }*/

        public ActionResult Search
            (
            int type,
            string w1,
            string w2,
            string w3,
            string w4,
            string w5,
            string w6,
            string w7,
            string w8
            )
        {
            if (type == 0)
            {
                var data = FindByNameContains(w1);
                return data;
            }
            else if (type == 2)
            {
                var data2 = GetNewestLawStatus(w1);
                return data2;
            }
            else
            {
                PATENTQuery pATENTQuery = new PATENTQuery();
                return pATENTQuery.SearchExpert
                    (
                    w1, w2, w3, w4, w5, w6, w7, w8
                    );
            }

        }

        public ActionResult SearchResult()
        {
            return View();
        }

        public ActionResult SearchByName()
        {
            string name = Request["searchStr"];
            var data = FindByNameContains(name);
            return data;
        }

        public ActionResult SearchLaw()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchLaw(string lawStr)
        {
            var data = GetNewestLawStatus(lawStr);
            return data;
        }

        /*public ActionResult SearchByLaw()
        {
            string name = Request["lawStr"];
            var data = GetNewestLawStatus(name);
            return data;
        }*/

        public ActionResult SearchForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchForm(string w1,string w2,string w3,string w4,string w5,string w6,string w7,string w8)
        {
            PATENTQuery pATENTQuery = new PATENTQuery();
            return pATENTQuery.SearchExpert
                (
                w1, w2, w3, w4, w5, w6, w7, w8
                );
        }

    }
}