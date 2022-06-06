using Hos.ScheduleMaster.Core.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hos.ScheduleMaster.QuartzHost.Filters
{
    public class ApiValidationFilter : Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    {
        public void OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context)
        {
            var anonymous = (context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), false);
            if (anonymous.Any())
            {
                return;
            }
            var secret = context.HttpContext.Request.Headers["sm_secret"].FirstOrDefault();
            //LogHelper.Info($"w:{Common.QuartzManager.AccessSecret} m:{secret}");
            if (string.Compare(Common.QuartzManager.AccessSecret, secret, StringComparison.CurrentCultureIgnoreCase) != 0)
            {
                context.Result = new UnauthorizedObjectResult($"w:{Common.QuartzManager.AccessSecret} m:{secret}");
            }
        }
    }
}
