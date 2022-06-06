using Hos.ScheduleMaster.Web.Extension;
using System;

namespace Hos.ScheduleMaster.Web.Filters
{
    /// <summary>
    /// 异步请求特性
    /// by hoho
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class AjaxRequestOnlyAttribute : Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    {
        public AjaxRequestOnlyAttribute()
        {
            this.Order = 1;
        }

        /// <summary>在执行操作方法之前由 ASP.NET MVC 框架调用。</summary>
        /// <param name="filterContext">筛选器上下文。</param>
        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            if (!request.IsAjaxRequest())
            {
                filterContext.Result = new Microsoft.AspNetCore.Mvc.RedirectResult("~/Static/Page404");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}