using BlueFox.AM.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueFox.AM.Web.Controllers
{
    [AllowCrossOriginAccess]
    public class UrlController : Controller
    {
        [HttpPost]
        public ActionResult Add(Url url)
        {
            url.Save();
            return Json(new { isSuccess = true });
        }
    }
}