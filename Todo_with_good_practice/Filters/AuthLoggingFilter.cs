using Microsoft.AspNetCore.Mvc.Filters;
using Todo_with_good_practice.Helpers;

namespace Todo_with_good_practice.Filters
{
    public class AuthLoggingFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // to know which action is called .... 
            var actionName = context.ActionDescriptor.DisplayName;
            string username = "";

            if (context.ActionArguments.ContainsKey("vm"))
            {
                // bring vm and get username property value
                // single responsibility principle  -> reflectiomn here is not good idea ?
                var vm = context.ActionArguments["vm"];
                username = vm?.GetType().GetProperty("Username")?.GetValue(vm)?.ToString() ?? "Unknown";
            }

            FileLogger.Log($"[START] Action: {actionName}, User: {username}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            FileLogger.Log($"[END] Action: {actionName}");
        }
    }
}
