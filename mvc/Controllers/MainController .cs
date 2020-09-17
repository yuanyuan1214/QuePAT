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
        static public JsonSerializerSettings jsSettings = new JsonSerializerSettings();
        private Entities db = new Entities();

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
            string json = JsonConvert.SerializeObject(findByNameContains(str).ToList(), jsSettings);
            return new ContentResult { Content = json };
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