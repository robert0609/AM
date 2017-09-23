using BlueFox.AM.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueFox.AM.Web.Controllers
{
    [AllowCrossOriginAccess]
    public class SiteController : Controller
    {
        [HttpPost]
        public ActionResult Add(Site site)
        {
            site.Save();
            return Json(new { isSuccess = true });
        }
    }
}