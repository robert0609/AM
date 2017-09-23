using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlueFox.AM.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            if (!HttpContext.Current.IsCustomErrorEnabled)
            {
                return;
            }
            var exception = Server.GetLastError();

            //is ajax request, then return;
            //if (HttpContext.Current.Request.Headers["X-Requested-With"] != null
            //  && HttpContext.Current.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //{
            //    return;
            //}
            
            var httpCode = 500;
            string message = null;
            var httpException = new HttpException(null, exception);
            httpCode = (httpException == null) ? 500 : httpException.GetHttpCode();
            message = httpException.Message;


            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Index");
            routeData.Values.Add("httpCode", httpCode);
            routeData.Values.Add("message", message);

            Server.ClearError();

            var errorController = ControllerBuilder.Current.GetControllerFactory().CreateController(new RequestContext(new HttpContextWrapper(Context), routeData), "Error");
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}
