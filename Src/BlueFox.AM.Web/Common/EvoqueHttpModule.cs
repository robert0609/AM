using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evoque.Demo.Common
{
    public class EvoqueHttpModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            var method = app.Context.Request.HttpMethod;
            //判断是否预检请求
            if (method.ToLower() == "options")
            {
                app.Context.Response.ClearContent();
                this.AddAllowOrigins(app.Context.Request, app.Context.Response);
                app.Context.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type,X-Requested-With";
                app.Context.Response.Headers["Access-Control-Allow-Methods"] = "POST,GET,OPTIONS";
                app.Context.Response.Headers["Access-Control-Allow-Credentials"] = "true";
                app.Context.Response.Headers["Access-Control-Max-Age"] = "30";
                app.Context.Response.Cookies.Clear();
                app.Context.Response.StatusCode = 200;
                app.CompleteRequest();
            }
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            var method = app.Context.Request.HttpMethod;
            //判断是否预检请求
            if (method.ToLower() != "options")
            {
                this.AddAllowOrigins(app.Context.Request, app.Context.Response);
                app.Context.Response.Headers["Access-Control-Allow-Credentials"] = "true";
                app.Context.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type,X-Requested-With";
            }
        }

        private void AddAllowOrigins(HttpRequest request, HttpResponse response)
        {
            var requestOrigin = request.Headers["Origin"];
            if (!string.IsNullOrWhiteSpace(requestOrigin))
            {
                response.Headers["Access-Control-Allow-Origin"] = requestOrigin;
            }
        }
    }
}