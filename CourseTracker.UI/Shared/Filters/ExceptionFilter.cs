using CourseTracker.UI.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CourseTracker.UI.Shared.Filters
{
    
    public class ExceptionFilter : IExceptionFilter
    {

        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;       
        }

        public void OnException(ExceptionContext context)
        {

            Exception exception = context.Exception;

            _logger.LogError(exception, $"- From ExceptionFilter {exception.Message}, {exception.StackTrace}");

            if (context.Exception is InvalidEntityIdException)
                context.Result = new RedirectToActionResult("Index", "Students", null);
            else
            {
                // Log
                context.HttpContext.Response.StatusCode = 500;
            }

        }


    }

}
