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
    public class HomeController : Controller
    {
        private Entities db = new Entities();
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Result()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Result(string str)
        {
            PATENTQuery pATENTQuery = new PATENTQuery();
            return pATENTQuery.FindByApplyNumber(str);
        }
        [HttpPost]
        public ActionResult Law(string str)
        {
            LAW_STATUSQuery lAW  = new LAW_STATUSQuery();
            return lAW.GetLawStatus(str);
        }
    }
}