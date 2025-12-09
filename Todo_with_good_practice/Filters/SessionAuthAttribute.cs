using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Todo_with_good_practice.Models; // your SessionUser model
using Newtonsoft.Json;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SessionAuthAttribute : ActionFilterAttribute
{
    // add dependency injection to call session service 
    // but it will need more setup  and cause problems ....
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var session = context.HttpContext.Session;
        var userJson = session.GetString("CurrentUser");

        // If no user in session → redirect to login
        if (string.IsNullOrEmpty(userJson))
        {
            // we can use context.HttpContext.Response.Redirect("/Auth/Login");
            // it depends on situation
            context.Result = new RedirectToActionResult("Login", "Auth", null);
        }

    }
}
