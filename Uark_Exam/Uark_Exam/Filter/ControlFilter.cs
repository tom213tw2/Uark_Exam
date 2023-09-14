using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json;
using NLog;


namespace Uark_Exam.Filter
{
    public class ControlFilter : ActionFilterAttribute
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var guId = GetGuId();
            if (!filterContext.HttpContext.Items.Contains("RequestGUID"))
            {
                filterContext.HttpContext.Items["RequestGUID"] = guId;
            }
            else
            {
                filterContext.HttpContext.Items.Add("RequestGUID", guId);
            }

            _logger.Info(filterContext.HttpContext.Request.HttpMethod.Equals("GET", StringComparison.OrdinalIgnoreCase)
                ? $"[{guId}][RequestFrom] URL :: {filterContext.HttpContext.Request.Path}, QueryString :: {filterContext.HttpContext.Request.QueryString}"
                : $"[{guId}][RequestFrom] URL :: {filterContext.HttpContext.Request.Path}, RequestBody :: {GetRequestBody(filterContext.ActionParameters)}");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var guId = filterContext.HttpContext.Items["RequestGUID"];
            if (filterContext.Exception != null) return;
            _logger.Info(
                $"[{guId}][Response] ResponseBody :: {JsonConvert.SerializeObject(GetActionExecutedContext(filterContext))}");

        }

        public JsonResult GetJsonResultString(object model)
        {
            return new JsonResult
            {
                Data = model,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }

        private object GetActionExecutedContext(ActionExecutedContext context)
        {
            switch (context.Result)
            {
                case ViewResult result:
                {
                    var contextResult = result;
                    return new
                    {
                        Model = contextResult.Model,
                        TempData = contextResult.TempData,
                        ViewBag = contextResult.ViewBag,
                        ViewData = contextResult.ViewData
                    };
                }
                case JsonResult result:
                {
                    var contextResult = result;
                    return new
                    {
                        Data = contextResult.Data
                    };
                }
            }

            return new
            {
                Data = ""
            };
        }

        private static string GetGuId()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
        }

        private static string GetRequestBody(IDictionary<string, object> contextActionArguments)
        {
            return contextActionArguments.Aggregate(new StringBuilder(),
                (sb, kvp) => sb.AppendFormat("{0}{1} = {2}", sb.Length > 0 ? ", " : "", kvp.Key,
                    JsonConvert.SerializeObject(kvp.Value)),
                sb => sb.ToString());
        }
    }
}