using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuePAT.Models;
using Newtonsoft.Json;
using System.Security.Permissions;

namespace QuePAT.Controllers
{
    public class FAMILYQuery : Controller
    {
        private Entities db = new Entities();

        public ActionResult FamilyOf(string app_num)
        {
            string basic = db.FAMILY
                .Where(f => f.APP_NUM.Equals(app_num))
                .Select(f => f.BASIC_APP_NUM)
                .FirstOrDefault();
            if (basic == null)
            {
                basic = db.FAMILY
                .Where(f => f.BASIC_APP_NUM.Equals(app_num))
                .Select(f => f.BASIC_APP_NUM)
                .FirstOrDefault();
            }
            if (basic != null)
            {
                IQueryable<string> family = db.FAMILY
                    .Where(f => f.BASIC_APP_NUM.Equals(basic))
                    .Select(f => f.BASIC_APP_NUM);
                return new ContentResult
                {
                    Content = JsonConvert.SerializeObject(family.ToList())
                };
            }
            return new ContentResult { Content = JsonConvert.SerializeObject(new List<string>()) };
        }
    }
}