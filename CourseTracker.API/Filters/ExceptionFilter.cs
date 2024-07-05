using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace CourseTracker.API.Filters
{
    
    public class ExceptionFilter : IExceptionFilter
    {

        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException (ExceptionContext context)
        {

            Exception exception = context.Exception;

            _logger.LogError($"- From ExceptionFilter {exception.Message}", exception);

            context.HttpContext.Response.StatusCode = 500;
            context.Result = new JsonResult(context);

        }

    }

}
