using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Todo_with_good_practice.Models; // your SessionUser model
using Newtonsoft.Json;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SessionAuthAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var session = context.HttpContext.Session;
        var userJson = session.GetString("CurrentUser");

        // If no user in session → redirect to login
        if (string.IsNullOrEmpty(userJson))
        {
            context.Result = new RedirectToActionResult("Login", "Auth", null);
        }
        else
        {
            // Optional: store deserialized user in HttpContext.Items
            context.HttpContext.Items["CurrentUser"] = JsonConvert.DeserializeObject<SessionUser>(userJson);
        }
    }
}
