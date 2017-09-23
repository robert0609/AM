using BlueFox.AM.Web.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueFox.AM.Web.Controllers
{
    public class AccountController : Controller
    {
        //public ActionResult List()
        //{
        //    using (var access = new Accessor(DataFileName))
        //    {
        //        access.Connect("bluefox");
        //        IList<SiteGroup> accountList = access.Load();

        //        return Json(new { isSuccess = true, data = accountList }, JsonRequestBehavior.AllowGet);
        //    }            
        //}

        public ActionResult Add(string id, string username, string password, string sitepId)
        {
            var n = AccessHelper.SaveAccount(id, username, password, sitepId);
            return Json(new { isSuccess = true, saveCount = n }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Fetch(string id = null)
        {
            var account = AccessHelper.LoadAccountById(id);
            return Json(new { isSuccess = true, data = account }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List(string siteId = null)
        {
            var list = AccessHelper.LoadAccount(siteId);
            return Json(new { isSuccess = true, data = list }, JsonRequestBehavior.AllowGet);
        }
    }
}