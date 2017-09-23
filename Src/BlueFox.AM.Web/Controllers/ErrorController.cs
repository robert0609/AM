using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueFox.AM.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(string message, int httpCode = 500)
        {
            Response.TrySkipIisCustomErrors = true;

            switch (httpCode)
            {
                case 403:
                    Response.StatusCode = 403;
                    break;
                case 404:
                    Response.StatusCode = 404;
                    break;
                default:
                    Response.StatusCode = 500;
                    break;
            }
            
            return Json(new { isSuccess = false, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}