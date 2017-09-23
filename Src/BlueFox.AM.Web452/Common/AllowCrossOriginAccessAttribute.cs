using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace BlueFox.AM.Web
{
    /// <summary>
    /// 若要允许Action被跨域的ajax请求访问，则使用此标记
    /// </summary>
    public class AllowCrossOriginAccessAttribute : ActionFilterAttribute
    {
        public AllowCrossOriginAccessAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpRequest = filterContext.HttpContext.Request;
            //判断是否预检请求
            if (httpRequest.HttpMethod.ToLower() == "options")
            {
                filterContext.HttpContext.Response.ClearContent();
                this.AddAllowOrigins(filterContext.HttpContext.Request, filterContext.HttpContext.Response);
                filterContext.HttpContext.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type,X-Requested-With";
                filterContext.HttpContext.Response.Headers["Access-Control-Allow-Methods"] = "POST,GET,OPTIONS";
                filterContext.HttpContext.Response.Headers["Access-Control-Allow-Credentials"] = "true";
                filterContext.HttpContext.Response.Headers["Access-Control-Max-Age"] = "30";
                filterContext.HttpContext.Response.Cookies.Clear();
                filterContext.Result = new EmptyResult();
                return;
            }
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            var httpRequest = filterContext.HttpContext.Request;
            //判断是否预检请求
            if (httpRequest.HttpMethod.ToLower() == "options")
            {
                filterContext.HttpContext.Response.ClearContent();
                this.AddAllowOrigins(filterContext.HttpContext.Request, filterContext.HttpContext.Response);
                filterContext.HttpContext.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type,X-Requested-With";
                filterContext.HttpContext.Response.Headers["Access-Control-Allow-Methods"] = "POST,GET,OPTIONS";
                filterContext.HttpContext.Response.Headers["Access-Control-Allow-Credentials"] = "true";
                filterContext.HttpContext.Response.Headers["Access-Control-Max-Age"] = "30";
                filterContext.HttpContext.Response.Cookies.Clear();
                filterContext.Result = new EmptyResult();
                return;
            }
            else
            {
                this.AddAllowOrigins(filterContext.HttpContext.Request, filterContext.HttpContext.Response);
                filterContext.HttpContext.Response.Headers["Access-Control-Allow-Credentials"] = "true";
                filterContext.HttpContext.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type,X-Requested-With";
            }
        }

        private void AddAllowOrigins(HttpRequestBase request, HttpResponseBase response)
        {
            var requestOrigin = request.Headers["Origin"];
            if (!string.IsNullOrWhiteSpace(requestOrigin))
            {
                response.Headers["Access-Control-Allow-Origin"] = requestOrigin;
            }
        }
    }
}
