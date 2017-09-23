using BlueFox.AM.Web.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueFox.AM.Web.Controllers
{
    public class UrlController : Controller
    {
        public ActionResult Add(string id, string urlString, string sitepId)
        {
            var n = AccessHelper.SaveUrl(id, urlString, sitepId);
            return Json(new { isSuccess = true, saveCount = n }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Fetch(string id = null)
        {
            var url = AccessHelper.LoadUrlById(id);
            return Json(new { isSuccess = true, data = url }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List(string siteId = null)
        {
            var list = AccessHelper.LoadUrl(siteId);
            return Json(new { isSuccess = true, data = list }, JsonRequestBehavior.AllowGet);
        }
    }
}