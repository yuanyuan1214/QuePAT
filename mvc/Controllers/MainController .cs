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
                .Select(p => new { NAME = p.NAME, APP_DATE = p.APP_DATE }
                )
                .ToList(), jsSettings);
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
        public ActionResult SearchByName()
        {
            string name = Request["searchStr"];
            var data = FindByNameContains(name);
            return data;
        }
    }
}