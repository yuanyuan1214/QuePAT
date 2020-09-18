using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Community_Module_of_QuePAT.Models;
using Microsoft.SqlServer.Server;
using Oracle.ManagedDataAccess.Types;

namespace Community_Module_of_QuePAT.Controllers
{



    public class DiscussionController : Controller
    {
        private CommunityEntities db = new CommunityEntities();

        // GET: Discussion
        public ActionResult Index()
        {
            var dISCUSSION = db.DISCUSSION.Include(d => d.USR);
            return View(dISCUSSION.ToList());
        }

        // GET: Discussion/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCUSSION dISCUSSION = db.DISCUSSION.Find(id);
            if (dISCUSSION == null)
            {
                return HttpNotFound();
            }
            return View(dISCUSSION);
        }

        // GET: Discussion/Create
        public ActionResult Create()
        {
            ViewBag.PUT_UP_USR_ID = new SelectList(db.USR, "USR_ID", "LOGIN_NAME");
            return View();
        }

        // POST: Discussion/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DISC_ID,PUT_UP_USR_ID,TOPIC,CONTENT,INIT_TIME")] DISCUSSION dISCUSSION)
        {
            if (ModelState.IsValid)
            {
                db.DISCUSSION.Add(dISCUSSION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PUT_UP_USR_ID = new SelectList(db.USR, "USR_ID", "LOGIN_NAME", dISCUSSION.PUT_UP_USR_ID);
            return View(dISCUSSION);
        }

        // GET: Discussion/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCUSSION dISCUSSION = db.DISCUSSION.Find(id);
            if (dISCUSSION == null)
            {
                return HttpNotFound();
            }
            ViewBag.PUT_UP_USR_ID = new SelectList(db.USR, "USR_ID", "LOGIN_NAME", dISCUSSION.PUT_UP_USR_ID);
            return View(dISCUSSION);
        }

        // POST: Discussion/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DISC_ID,PUT_UP_USR_ID,TOPIC,CONTENT,INIT_TIME")] DISCUSSION dISCUSSION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISCUSSION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PUT_UP_USR_ID = new SelectList(db.USR, "USR_ID", "LOGIN_NAME", dISCUSSION.PUT_UP_USR_ID);
            return View(dISCUSSION);
        }

        // GET: Discussion/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCUSSION dISCUSSION = db.DISCUSSION.Find(id);
            if (dISCUSSION == null)
            {
                return HttpNotFound();
            }
            return View(dISCUSSION);
        }

        // POST: Discussion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            DISCUSSION dISCUSSION = db.DISCUSSION.Find(id);
            db.DISCUSSION.Remove(dISCUSSION);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult BlogMain()
        {
            return View();
        }

        public ActionResult BlogEdit()
        {
            return View();
        }

        public ActionResult BlogDetail()
        {
            return View();
        }
        public ActionResult MyBlog()
        {
            return View();
        }


        private static int ConvertDateTimeInt(DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /*
         * 创建新的议题
         * @param usr_id 用户ID
         * @param topic 议题标题
         * @param content 议题正文
         */
        public ActionResult CreateDisc()
        {
            var usr_id = Request["usr_id"];
            var topic = Request["topic"];
            var content = HttpUtility.UrlDecode(Request["content"]);

            string queryStr = "SELECT * FROM SYSTEM.DISCUSSION ORDER BY DISC_ID";
            IEnumerable<DISCUSSION> allDisc = db.Database.SqlQuery<DISCUSSION>(queryStr);
            // 获取DISC_ID
            var disc_id = allDisc.Last().DISC_ID + 1;
            string insertStr = "INSERT INTO SYSTEM.DISCUSSION VALUES('" + disc_id + "', '"
                + usr_id + "', '" + topic + "', '" + content + "', to_date('" + System.DateTime.Now + "','yyyy-mm-dd hh24:mi:ss'))";
            System.Diagnostics.Debug.WriteLine(insertStr);
            return Content(db.Database.ExecuteSqlCommand(insertStr).ToString());
        }

        /*
         * 删除议题
         * @param disc_id 议题ID
         */
        public ActionResult DeleteDisc()
        {
            var disc_id = Request["disc_id"];
            string deleteStr = "DELETE FROM SYSTEM.DISCUSSION WHERE DISC_ID = '" + disc_id + "'";

            return Content(db.Database.ExecuteSqlCommand(deleteStr).ToString());
        }

        /*
         * 修改议题
         * @param disc_id 议题ID
         * @param topic 议题标题
         * @param content 议题正文
         */
        public ActionResult UpdateDisc()
        {
            var disc_id = Request.Form["disc_id"];
            var topic = Request.Form["topic"];
            var content = Request.Form["content"];

            string updateStr = "UPDATE SYSTEM.DISCUSSION SET TOPIC = '" + topic +
                "', CONTENT = '" + content + "' WHERE DISC_ID = '" + disc_id + "'";

            return Content(db.Database.ExecuteSqlCommand(updateStr).ToString());
        }

        /* 
         * 根据用户ID查询用户发起的议题,获取议题的列表
         * @param usr_ID 用户ID
         */
        public List<DISCUSSION> QueryByUsrID(int usr_ID)
        {
            //var usr_ID = Request.Form["usr_ID"];
            string querystr = "SELECT * FROM SYSTEM.DISCUSSION WHERE PUT_UP_USR_ID = '" +  usr_ID + "' ORDER BY INIT_TIME DESC";

            IEnumerable<DISCUSSION> ret = db.Database.SqlQuery<DISCUSSION>(querystr);
            List<DISCUSSION> a = ret.ToList();

            return ret.ToList();

        }

        public List<DISCUSSION> QueryByUsrID()
        {
            var usr_ID = Request.Form["usr_ID"];
            string querystr = "SELECT * FROM SYSTEM.DISCUSSION WHERE PUT_UP_USR_ID = '" + usr_ID + "ORDER BY INIT_TIME DESC'";

            IEnumerable<DISCUSSION> ret = db.Database.SqlQuery<DISCUSSION>(querystr);
            int i = db.Database.ExecuteSqlCommand(querystr);
            if (i == -1)
            {
                return null;
            }
            else
            {
                return ret.ToList();
            }
        }

        /* 
         * 根据议题ID查询用户发起的议题,获取议题的列表
         * @param disc_ID 议题ID
         */
        public List<DISCUSSION> QueryByDiscID(string disc_ID)
        {
            string querystr = "SELECT * FROM SYSTEM.DISCUSSION WHERE DISC_ID = '" + disc_ID + "'";

            IEnumerable<DISCUSSION> ret = db.Database.SqlQuery<DISCUSSION>(querystr);

            return ret.ToList();
        }

        /*
         * 关键词搜索议题
         * @param keyword 关键词，即搜索框中的文本内容
         *      可搜索关键词、文章内容、用户ID
         */
        public List<DISCUSSION> QueryByKeywords(string keyword)
        {
            //var keyword = Request.Form["keyword"];

            List<DISCUSSION> allDisc = db.Database.SqlQuery<DISCUSSION>("SELECT * FROM SYSTEM.DISCUSSION ORDER BY INIT_TIME DESC").ToList();
            List<DISCUSSION> result = new List<DISCUSSION>();
            foreach(var item in allDisc)
            {
                if(MatchOneWord(item.CONTENT, keyword) || MatchOneWord(item.TOPIC, keyword) ||
                    MatchOneWord(item.PUT_UP_USR_ID.ToString(), keyword))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        /*
         * 根据用户ID和关键词搜索议题，在用户ID的约束下进行关键词搜索
         */
        public List<DISCUSSION> QueryByKeywordsAndUsrID(string keyword, int usr_ID)
        {
            //var keyword = Request.Form["keyword"];

            List<DISCUSSION> allDisc = db.Database.SqlQuery<DISCUSSION>("SELECT * FROM SYSTEM.DISCUSSION WHERE PUT_UP_USR_ID='" +
                usr_ID + "' ORDER BY INIT_TIME DESC").ToList();
            List<DISCUSSION> result = new List<DISCUSSION>();
            foreach (var item in allDisc)
            {
                if (MatchOneWord(item.CONTENT, keyword) || MatchOneWord(item.TOPIC, keyword))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        // 匹配字符串
        private static bool MatchOneWord(string str, string word)
        {
            if(str == null || word == null || str == "" || word == "")
            {
                return false;
            }
            
            int i = 0;
            int j = 0;
            while (i < str.Length && j <= word.Length)
            {
                if (str[i] == word[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    i++;
                    j = 0;
                }
                if (j == word.Length)
                {
                    return true;
                }
            }
            return false;
        }

        /*
         * 获取所有议题
         */
        public List<DISCUSSION> GetAllDisc()
        {
            string querystr = "SELECT * FROM SYSTEM.DISCUSSION ORDER BY INIT_TIME DESC";

            IEnumerable<DISCUSSION> ret = db.Database.SqlQuery<DISCUSSION>(querystr);

            return ret.ToList();
        }

        /*
         * 创建评论
         * @param disc_id 议题ID
         * @param usr_id 用户ID
         * @param content 评论内容
         */
        public ActionResult CreateCmt()
        {
            var disc_id = Request.Form["disc_id"];
            var usr_id = Request.Form["usr_id"];
            var content = Request.Form["content"];

            if(content == "")
            {
                return null;
            }

            string insertStr = "INSERT INTO SYSTEM.CMNT VALUES('" + disc_id + "', '" +
                usr_id + "', to_date('" + System.DateTime.Now + "','yyyy-mm-dd hh24:mi:ss'), '" + content + "', '0')";

            System.Diagnostics.Debug.WriteLine(insertStr);
            return Content(db.Database.ExecuteSqlCommand(insertStr).ToString());
        }

        /*
         * 删除评论
         */
        public ActionResult DeleteCmt()
        {
            return Content(" ");
        }

        /*
         * 查找议题下的所有评论
         */
        public List<CMNT> QueryCmtByDisc(string disc_id)
        {
            string queryStr = "SELECT * FROM SYSTEM.CMNT WHERE DISC_ID = '" + disc_id + "'";

            IEnumerable<CMNT> ret = db.Database.SqlQuery<CMNT>(queryStr);

            return ret.ToList();
        }
    }
}
