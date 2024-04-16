using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TrainSystem.Entities;
using TrainSystem.Extensions;

namespace TrainSystem.FIlters
{
    public class AuthenticationFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObject<User>("loggedUser") == null)
            {
                string requestPath = context.HttpContext.Request.Path.Value;

                context.Result = new RedirectResult("/Home/Login?url=" + requestPath);
            }
        }
    }
}
