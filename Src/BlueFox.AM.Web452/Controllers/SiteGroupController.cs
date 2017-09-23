using BlueFox.AM.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueFox.AM.Web.Controllers
{
    //[AllowCrossOriginAccess]
    public class SiteGroupController : Controller
    {
        [HttpPost]
        public ActionResult Add(SiteGroup group)
        {
            group.Save();
            return Json(new { isSuccess = true });
        }

        public ActionResult Fetch(string id = null)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new { isSuccess = true, data = new SiteGroup() }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                using (Accessor access = new Accessor())
                {
                    access.Connect();
                    var siteGroup = access.LoadSiteGroup(id);
                    return Json(new { isSuccess = true, data = siteGroup }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var httpRequest = filterContext.HttpContext.Request;
        //    //判断是否预检请求
        //    if (httpRequest.HttpMethod.ToLower() == "options")
        //    {
        //        filterContext.HttpContext.Response.ClearContent();
        //        this.AddAllowOrigins(filterContext.HttpContext.Request, filterContext.HttpContext.Response);
        //        filterContext.HttpContext.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type,X-Requested-With";
        //        filterContext.HttpContext.Response.Headers["Access-Control-Allow-Methods"] = "POST,GET,OPTIONS";
        //        filterContext.HttpContext.Response.Headers["Access-Control-Allow-Credentials"] = "true";
        //        filterContext.HttpContext.Response.Headers["Access-Control-Max-Age"] = "30";
        //        filterContext.HttpContext.Response.Cookies.Clear();
        //        filterContext.Result = new EmptyResult();
        //        return;
        //    }
        //    base.OnActionExecuting(filterContext);
        //}

        //protected override void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //    base.OnResultExecuted(filterContext);
        //    var httpRequest = filterContext.HttpContext.Request;
        //    //判断是否预检请求
        //    if (httpRequest.HttpMethod.ToLower() == "options")
        //    {
        //        filterContext.HttpContext.Response.ClearContent();
        //        this.AddAllowOrigins(filterContext.HttpContext.Request, filterContext.HttpContext.Response);
        //        filterContext.HttpContext.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type,X-Requested-With";
        //        filterContext.HttpContext.Response.Headers["Access-Control-Allow-Methods"] = "POST,GET,OPTIONS";
        //        filterContext.HttpContext.Response.Headers["Access-Control-Allow-Credentials"] = "true";
        //        filterContext.HttpContext.Response.Headers["Access-Control-Max-Age"] = "30";
        //        filterContext.HttpContext.Response.Cookies.Clear();
        //        filterContext.Result = new EmptyResult();
        //        return;
        //    }
        //    else
        //    {
        //        this.AddAllowOrigins(filterContext.HttpContext.Request, filterContext.HttpContext.Response);
        //        filterContext.HttpContext.Response.Headers["Access-Control-Allow-Credentials"] = "true";
        //        filterContext.HttpContext.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type,X-Requested-With";
        //    }
        //}

        //private void AddAllowOrigins(HttpRequestBase request, HttpResponseBase response)
        //{
        //    var requestOrigin = request.Headers["Origin"];
        //    if (!string.IsNullOrWhiteSpace(requestOrigin))
        //    {
        //        response.Headers["Access-Control-Allow-Origin"] = requestOrigin;
        //    }
        //}
    }
}