using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MonofiaQ3WebApp26.Filtters
{
    public class HandelErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult result=new ContentResult();
            //result.Content =  context.Exception.Message;
            //context.Result=result;
            ViewResult result = new ViewResult();
            result.ViewName= "Error";

            context.Result = result;
        }
    }
}
