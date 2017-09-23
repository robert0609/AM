using BlueFox.AM.Web.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueFox.AM.Web.Controllers
{
    public class SiteGroupController : Controller
    {
        public ActionResult Add(string id, string groupName)
        {
            var n = AccessHelper.SaveSiteGroup(id, groupName);
            return Json(new { isSuccess = true, saveCount = n }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Fetch(string id = null)
        {
            var siteGroup = AccessHelper.LoadSiteGroupById(id);
            return Json(new { isSuccess = true, data = siteGroup }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            var list = AccessHelper.LoadSiteGroup();
            return Json(new { isSuccess = true, data = list }, JsonRequestBehavior.AllowGet);
        }
    }
}