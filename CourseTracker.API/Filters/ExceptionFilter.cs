using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

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
            string details = GetExceptionDetails(exception);

            _logger.LogError(exception, $"- From ExceptionFilter {exception.Message}, {exception.StackTrace}");

            context.HttpContext.Response.StatusCode = 500;
            context.Result = new JsonResult(context);

        }

        private string GetExceptionDetails(Exception exception)
        {

            string result = null;



            return result;

        }

    }

}
