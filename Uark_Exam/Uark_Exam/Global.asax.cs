using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using NLog;

namespace Uark_Exam
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var logger = LogManager.GetCurrentClassLogger();
            var unhandledException = Server.GetLastError();
            var guId = HttpContext.Current.Items["RequestGUID"];

            if (unhandledException == null) return;
            Server.ClearError();

            logger.Error($"[{guId}][Response] Application occurred Exception");
            logger.Error($"[{guId}][Exception] :: {unhandledException.Message}");
            logger.Error($"[{guId}][Exception] :: {unhandledException.StackTrace}");
            


            Response.Redirect($"~/Error/Index");
        }
    }
}