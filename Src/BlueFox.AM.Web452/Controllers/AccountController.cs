using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlueFox.AM.DAO;

namespace BlueFox.AM.Web.Controllers
{
    [AllowCrossOriginAccess]
    public class AccountController : Controller
    {
        private readonly static string DataFileName = System.Web.HttpContext.Current.Server.MapPath("/bluefox.am");

        public ActionResult List()
        {
            using (var access = new Accessor(DataFileName))
            {
                access.Connect("bluefox");
                IList<SiteGroup> accountList = access.Load();

                return Json(new { data = accountList }, JsonRequestBehavior.AllowGet);
            }            
        }

        [HttpPost]
        public ActionResult Add(Account account)
        {
            account.Save();
            return Json(new { isSuccess = true });
        }
    }
}