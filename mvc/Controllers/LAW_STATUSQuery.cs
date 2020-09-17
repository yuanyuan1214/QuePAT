using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using QuePAT.Models;
using Newtonsoft.Json;

namespace QuePAT.Controllers
{
    public class LAW_STATUSQuery : Control
    {
        private Entities db = new Entities();

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
            IQueryable<LAW_STATUS> lAW_STATUS = db.LAW_STATUS.Where(l => l.APP_NUM == app_num)
                .OrderByDescending(l => l.ANNOUNCE_DATE);
            string json = JsonConvert.SerializeObject(lAW_STATUS.ToList());
            return new ContentResult { Content = json };
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
            string json = JsonConvert.SerializeObject(lAW_STATUS);
            return new ContentResult { Content = json };
        }
    }
}