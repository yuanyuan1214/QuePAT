using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using QuePAT.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuePAT.Controllers
{
    public class LAW_STATUSQuery : Control
    {
        static JsonSerializerSettings jsSettings = new JsonSerializerSettings();
        private Entities db = new Entities();

        public LAW_STATUSQuery()
        {
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        // get law status of app_num, ordered by announce date decending.
        public IQueryable<LAW_STATUS> getLawStatus(string app_num)
        {
            IQueryable<LAW_STATUS> lAW_STATUS = db.LAW_STATUS.Where(l => l.APP_NUM == app_num)
                .OrderByDescending(l => l.ANNOUNCE_DATE);
            return lAW_STATUS;
        }

        // get law status of app_num, ordered by announce date decending.
        public ActionResult GetLawStatus(string app_num)
        {
            Newtonsoft.Json.Linq.JArray jArray = new Newtonsoft.Json.Linq.JArray();
            IQueryable<LAW_STATUS> lAW_STATUS = db.LAW_STATUS.Where(l => l.APP_NUM == app_num)
                .OrderByDescending(l => l.ANNOUNCE_DATE);
            foreach (var item in lAW_STATUS)
            {
                jArray.Add(JToken.FromObject(item, new JsonSerializer
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Arrays,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
            }
            return new ContentResult { Content = jArray.ToString() };
        }

        // get newest law status of app_num.
        public LAW_STATUS getNewestLawStatus(string app_num)
        {
            LAW_STATUS lAW_STATUS = getLawStatus(app_num).FirstOrDefault();
            return lAW_STATUS;
        }

        // get newest law status of app_num.
        public ActionResult GetNewestLawStatus(string app_num)
        {
            LAW_STATUS lAW_STATUS = getNewestLawStatus(app_num);
            string json = JsonConvert.SerializeObject(lAW_STATUS, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Arrays,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
            );
            return new ContentResult { Content = json };
        }
    }
}