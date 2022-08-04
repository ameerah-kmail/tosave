using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Task4_userAPI.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var a = context.HttpContext.Request.Headers["Role"];
            if (a == "admin")
            {
                return;
            }
            else
            {
                context.Result = new BadRequestObjectResult("you are not the admin");
            }
        }
    }
}
