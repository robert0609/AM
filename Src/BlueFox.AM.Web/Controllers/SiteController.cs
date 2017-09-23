using BlueFox.AM.Web.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueFox.AM.Web.Controllers
{
    public class SiteController : Controller
    {
        public ActionResult Add(string id, string siteName, string siteGroupId)
        {
            var n = AccessHelper.SaveSite(id, siteName, siteGroupId);
            return Json(new { isSuccess = true, saveCount = n }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Fetch(string id = null)
        {
            var site = AccessHelper.LoadSiteById(id);
            return Json(new { isSuccess = true, data = site }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List(string siteGroupId = null)
        {
            var list = AccessHelper.LoadSite(siteGroupId);
            return Json(new { isSuccess = true, data = list }, JsonRequestBehavior.AllowGet);
        }
    }
}