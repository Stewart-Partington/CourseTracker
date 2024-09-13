using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace CourseTracker.AzureFunctions
{
    public class Function
    {
        private readonly ILogger _logger;

        public Function(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function>();
        }

        [Function("Function")]
        public IEnumerable<Object> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequestData req,
            [SqlInput("SELECT * FROM [dbo].[Students]",
            "SqlConnectionString")] IEnumerable<Object> result)
        {
            _logger.LogInformation("C# HTTP trigger with SQL Input Binding function processed a request.");

            return result;
        }
    }
}
