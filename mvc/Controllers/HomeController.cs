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
        [HttpPost]
        public ActionResult Famliy(string str)
        {
            FAMILYQuery fAMILYQuery  = new FAMILYQuery();
            return fAMILYQuery.FamilyOf(str);
        }
        [HttpPost]
        public ActionResult Year(string str)
        {
            PATENTQuery pATENTQuery = new PATENTQuery();
            return pATENTQuery.PatentNumInYear(str);
        }
        [HttpPost]
        public ActionResult Type(string str)
        {
            PATENTQuery pATENTQuery = new PATENTQuery();
            return pATENTQuery.PatentNumOfType(str);
        }



        public ActionResult MainPage()
        {
            return View();
        }
        public ActionResult RegisterPage()
        {
            return View();
        }
        public ActionResult initial()
        {
            return View();
        }


        public ActionResult Register()
        {
            string reuserid = Request["re_userid"];
            string conrepwd = Request["con_re_pwd"];
            string repwd = Request["re_pwd"];

            string phone = Request["Phone"];
            string email = Request["Email"];

            string queryStr = "SELECT * FROM SYSTEM.USR ORDER BY USR_ID";
            IEnumerable<USR> allDisc = db.Database.SqlQuery<USR>(queryStr);
            // 获取DISC_ID
            var disc_id = allDisc.Last().USR_ID + 1;
            string str = "INSERT INTO SYSTEM.USR VALUES('" + disc_id + "','" + reuserid + "', '" + repwd + "','19-9月 -20 05.41.12.407000000 上午','" + repwd + "','" + repwd + "','" + repwd + "','" + repwd + "','0')";
            return Content(db.Database.ExecuteSqlCommand(str).ToString());
            // return Content("Register success.");
        }
        public ActionResult Logout()
        {
            string uid = Request["user_id"];
            string updateStr = "UPDATE SYSTEM.USR SET ONLOGIN='1'WHERE LOGIN_NAME='" + uid + "'";
            db.Database.ExecuteSqlCommand(updateStr);
            return Content("Logout success.");

        }
        public ActionResult Login()
        {
            string uid = Request["user_id"];
            string pwd = Request["password"];
            string Mark = Request["mark"];
            if (int.Parse(Mark) == 1)//管理员
            {
                if (uid != "cfjy")
                {
                    return Content("You are not admin");
                }
                string str1 = "SELECT PASSWORD FROM SYSTEM.USR WHERE LOGIN_NAME = '" + uid + "'";
                IEnumerable<string> result1 = db.Database.SqlQuery<string>(str1);
                if (result1.Count() == 0) return Content("No such user.");
                if (result1.ToList().First() != pwd) return Content("Wrong password.");

                string loginStr1 = "SELECT ONLOGIN FROM SYSTEM.USR WHERE LOGIN_NAME = '" + uid + "'";
                IEnumerable<decimal> onlogin1 = db.Database.SqlQuery<decimal>(loginStr1);

                // 获取DISC_ID
                var judge1 = onlogin1.First();
                if (judge1 == 1)
                {

                    return Content("You have logined");

                }
                if (judge1 == 0)
                {
                    string updateStr = "UPDATE SYSTEM.USR SET ONLOGIN='1'WHERE LOGIN_NAME='" + uid + "'";
                    db.Database.ExecuteSqlCommand(updateStr);
                    return Content("Login success.");

                }

            }
            string str = "SELECT PASSWORD FROM SYSTEM.USR WHERE LOGIN_NAME = '" + uid + "'";
            IEnumerable<string> result = db.Database.SqlQuery<string>(str);
            if (result.Count() == 0) return Content("No such user.");
            if (result.ToList().First() != pwd) return Content("Wrong password.");

            string loginStr = "SELECT ONLOGIN FROM SYSTEM.USR WHERE LOGIN_NAME = '" + uid + "'";
            IEnumerable<decimal> onlogin = db.Database.SqlQuery<decimal>(loginStr);

            // 获取DISC_ID
            var judge = onlogin.First();
            if (judge == 1)
            {

                return Content("You have logined");

            }
            if (judge == 0)
            {
                string updateStr = "UPDATE SYSTEM.USR SET ONLOGIN='1'WHERE LOGIN_NAME='" + uid + "'";
                db.Database.ExecuteSqlCommand(updateStr);
                return Content("Login success.");

            }




            return Content("lalala");
        }
    }
    }