using Microsoft.AspNetCore.Mvc.Filters;

namespace MonofiaQ3WebApp26.Filtters
{
    public class MyFilterAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //logic
            //context.

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //logic

        }
    }
}
