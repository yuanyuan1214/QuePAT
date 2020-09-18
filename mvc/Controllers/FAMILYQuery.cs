using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuePAT.Models;
using Newtonsoft.Json;
using System.Security.Permissions;
using System.Data.Entity;

namespace QuePAT.Controllers
{
    public class FAMILYQuery : Controller
    {
        static JsonSerializerSettings jsSettings = new JsonSerializerSettings();
        private Entities db = new Entities();

        public FAMILYQuery()
        {
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        public ActionResult FamilyOf(string app_num)
        {
            List<string> AppNum = new List<string>();
            string basic = db.FAMILY
                .Where(f => f.APP_NUM.Equals(app_num))
                .Select(f => f.BASIC_APP_NUM)
                .FirstOrDefault();

            AppNum.Add(app_num);
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
                    .Select(f => f.BASIC_APP_NUM)
                    .Union(AppNum);
                return new ContentResult
                {
                    Content = JsonConvert.SerializeObject(family.ToList(), jsSettings)
                };
            }
            return new ContentResult { Content = JsonConvert.SerializeObject(new List<string>()) };
        }
    }
}
