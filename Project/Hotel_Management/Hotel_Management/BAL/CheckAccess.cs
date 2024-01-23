using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static System.Formats.Asn1.AsnWriter;

namespace Hotel_Management.BAL
{
	public class CheckAccess : ActionFilterAttribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext filterContext)
		{
			if (filterContext.HttpContext.Session.GetString("UserID") == null)
				filterContext.Result = new RedirectResult("~/SEC_User/Index");
		}
		public override void OnResultExecuting(ResultExecutingContext context)
		{
			context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no - store, must - revalidate";
			context.HttpContext.Response.Headers["Expires"] = "-1";
			context.HttpContext.Response.Headers["Pragma"] = "no-cache";
			base.OnResultExecuting(context);
		}

	}
}
