using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CourseTracker.API.Filters
{
    
    public class ExceptionFilter : IExceptionFilter
    {

        public void OnException (ExceptionContext context)
        {

            Exception exception = context.Exception;

            context.HttpContext.Response.StatusCode = 500;
            context.Result = new JsonResult(context);

        }

    }

}
