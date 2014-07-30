using System;
using System.Web;
using System.Web.Mvc;

namespace WebScheduler.Filters
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class InitializeLocaleManagerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //LocalizedStringsManager.Initialize(filterContext.HttpContext.Request);
            try
            {
                LocalizedStringsManager.Initialize(filterContext.HttpContext.Request);
            }
            catch (Exception)
            {
                filterContext.HttpContext.Response.Cookies.Add(new HttpCookie("lang", "en") { Path = "/*" });
                LocalizedStringsManager.Initialize("en");
            }
        }
    }
}