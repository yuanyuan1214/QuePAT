using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QuePAT.Models;

namespace QuePAT.Controllers
{
    public class ADMINsController : Controller
    {
        // GET: ADMINs

        static JsonSerializerSettings jsSettings = new JsonSerializerSettings();

        private Entities db = new Entities();

        public ADMINsController()
        {
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        public ActionResult AdminMain()
        {
            return View();
        }

        //新的类，不必有实体
        public class PATENT_INFO
        {
            public string APP_NUM;
            public string NAME;
            public string PATENTEE_NAME;
        }

        //POST:
        //返回查询结果
        public List<PATENT_INFO> ListInfo()
        {
            List<PATENT_INFO> patent_infos = new List<PATENT_INFO>();
            var patentAppnum = from pt in db.PATENT
                               select pt;
            if (patentAppnum == null)
            {
                return patent_infos;
            }
            var patentAppnums = patentAppnum.ToList();
            foreach (var p in patentAppnums)
            {
                PATENT_INFO pi = new PATENT_INFO();
                pi.APP_NUM = p.APP_NUM;
                pi.NAME = p.NAME;
                pi.PATENTEE_NAME = p.PATENTEE_NAME;
                patent_infos.Add(pi);
            }

            return patent_infos;
            
        }

        public ActionResult GetPatentById()
        {
            string app_num = Request["app_num"];

            PATENT pATENT = db.PATENT.Find(app_num);
            ContentResult ret = new ContentResult{ Content =  JsonConvert.SerializeObject(pATENT, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, PreserveReferencesHandling = PreserveReferencesHandling.Arrays }) };
            return ret;
            
        }

        //POST:更改数据库patent表
        //返回值含义
        //1：成功
        //-01：要添加的公司已存在
        //-02：要添加的人已存在
        //-11：新公司已添加，但缺少专利权人在company中的记录。需要二次填报。
        //-12：新公司已添加，但缺少申请人在company中的记录。需要二次填报。
        //-13：新自然人已添加，但缺少发明人在person中的记录。提醒检查是否加错了。
        //-21：管理员没有添加新公司而且缺少专利权人在company中的记录。
        //-22：管理员没有添加新公司而且缺少专利权人申请人在company中的记录。
        //-23：管理员没有添加新自然人而且缺少发明人在person中的记录。
        //-31：db.saveChange()添加的公司/人时失败，未知错误。
        //-32：db.saveChange()添加/修改专利失败，未知错误。createDelete会回滚。
        //-41：修改专利，要改app_num，找不到ori_app_num的专利
        //-42：修改专利，不改app_num，找不到app_num的专利
        public ActionResult ModifyPatentDB()
        {
            //return Content("aaa");


            bool add_company = false, add_person = false;

            if (Request["com_name1"] != "")
            {
                COMPANY cOMPANY = new COMPANY();
                cOMPANY.NAME = Request["com_name1"];
                cOMPANY.ABSTRACT = Request["com_abstract1"];
                if (cOMPANY.ABSTRACT == "") cOMPANY.ABSTRACT = null;
                cOMPANY.ADDRESS = Request["com_address1"];
                if (cOMPANY.ADDRESS == "") cOMPANY.ADDRESS = null;
                if (db.COMPANY.Find(cOMPANY.NAME) != null) return Content("-01");
                db.COMPANY.Add(cOMPANY);
                add_company = true;
            }

            if (Request["com_name2"] != "")
            {
                COMPANY cOMPANY = new COMPANY();
                cOMPANY.NAME = Request["com_name2"];
                cOMPANY.ABSTRACT = Request["com_abstract2"];
                if (cOMPANY.ABSTRACT == "") cOMPANY.ABSTRACT = null;
                cOMPANY.ADDRESS = Request["com_address2"];
                if (cOMPANY.ADDRESS == "") cOMPANY.ADDRESS = null;
                if (db.COMPANY.Find(cOMPANY.NAME) != null) return Content("-01");
                db.COMPANY.Add(cOMPANY);
                add_company = true;
            }

            if (Request["person_name"] != "")
            {
                PERSON pERSON = new PERSON();
                pERSON.ID = Request["person_id"];
                pERSON.NAME = Request["person_name"];
                pERSON.ADDRESS = Request["person_address"];
                if (pERSON.ADDRESS == "") pERSON.ADDRESS = null;
                pERSON.PHONE_NUM = Request["person_phonenum"];
                if (pERSON.PHONE_NUM == "") pERSON.PHONE_NUM = null;
                pERSON.EMAIL = Request["person_email"];
                if (pERSON.EMAIL == "") pERSON.EMAIL = null;
                if (db.PERSON.Find(pERSON.ID) != null) return Content("-02");
                db.PERSON.Add(pERSON);
                add_person = true;
            }
            try
            {
                db.SaveChanges();
            }
            catch
            {
                return Content("-31");
            }


            PATENT pATENT = new PATENT();
            string act = Request["act"];

            string ori_app_num = Request["ori_app_num"];
            string app_num = Request["app_num"];

            PATENT oriPATENT = db.PATENT.Find(ori_app_num);
            if (act != "create")  //就是修改modify了
            {
                if (app_num != ori_app_num)   //改app_num
                {
                    if (oriPATENT == null) return Content("-41");
                    act = "createDelete";
                }
                else   //不改app_num
                {
                    pATENT = db.PATENT.Find(app_num);
                    if (pATENT == null)
                    {
                        return Content("-42");
                    }
                }
            }

            pATENT.APP_NUM = Request["app_num"];
            pATENT.NAME = Request["name"];
            pATENT.PATENT_TYPE = decimal.Parse(Request["patent_type"]);
            pATENT.CLASS_CODE = Request["class_code"];
            pATENT.DESIGNER_ID = Request["designer_id"];
            pATENT.PATENTEE_NAME = Request["patentee_name"];
            pATENT.PROPOSER_NAME = Request["proposer_name"];
            pATENT.PLACE_CODE = Request["place_code"];
            pATENT.APP_DATE = System.DateTime.Parse(Request["app_date"]);
            pATENT.PUBLIC_NUM = Request["public_num"];
            pATENT.ABSTRACT = Request["abstract"];
            pATENT.MAIN_CLAIM = Request["main_claim"];
            pATENT.CLAIM = Request["claim"];
            pATENT.AGE = decimal.Parse(Request["age"]);
            pATENT.IS_VALID = Request["is_valid"];
            pATENT.LINK = Request["link"];
            

            if (db.COMPANY.Find(pATENT.PATENTEE_NAME) == null)
            {
                if (add_company) return Content("-11");
                else return Content("-21");
            }
            if (db.COMPANY.Find(pATENT.PROPOSER_NAME) == null)
            {
                if (add_company) return Content("-12");
                else return Content("-22");
            }
            if (db.PERSON.Find(pATENT.DESIGNER_ID) == null)
            {
                if (add_person) return Content("-13");
                else return Content("-23");
            }

            if (act == "create")
            {
                db.PATENT.Add(pATENT);
            }
            else if (act == "createDelete")
            {
                db.PATENT.Add(pATENT);
                db.PATENT.Remove(oriPATENT);
            }


            try
            {
                db.SaveChanges();
            }
            catch
            {
                return Content("-32");
            }


            return Content("1");
        }

        //POST:
        //根据申请号删除专利
        //-01：要删除的专利找不到申请号
        //-32：删除专利失败
        //  1：删除成功
        public ActionResult DeletePATENT()
        {
            string app_num = Request["app_num"];
            
            PATENT pATENT = db.PATENT.Find(app_num);

            if (pATENT == null)
            {
                return Content("-01");
            }
            else
            {
                try
                {
                    db.PATENT.Remove(pATENT);
                    db.SaveChanges();
                    return Content("1");
                }
                catch
                {
                    return Content("-32");
                }
            }
        }

    }
}