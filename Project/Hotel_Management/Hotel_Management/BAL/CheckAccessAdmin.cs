using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.BAL
{
    public class CheckAccessAdmin : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("IsAdmin") == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Error");
            }
            else
            {
                bool IsAdmin = Convert.ToBoolean(filterContext.HttpContext.Session.GetString("IsAdmin"));
                if (!IsAdmin)
                {
                    filterContext.Result = new RedirectResult("~/Home/Error");
                }
            }
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            context.HttpContext.Response.Headers["Expires"] = "-1";
            context.HttpContext.Response.Headers["Pragma"] = "no-cache";
            base.OnResultExecuting(context);
        }
    }
}