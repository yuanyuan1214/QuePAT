﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuePAT.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult FindByApplyNumber(string str)
        {
            PATENTQuery pATENTQuery = new PATENTQuery();
            return pATENTQuery.FindByApplyNumber(str);
        }

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

        public ActionResult result()
        {
            return View();
        }
    }
}