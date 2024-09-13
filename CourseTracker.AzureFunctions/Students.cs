using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CourseTracker.AzureFunctions
{
    
    public class Students
    {
        
        private readonly ILogger _logger;

        public Students(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Students>();
        }

        [Function("GetSudents")]
        public HttpResponseData GetSudents([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route ="Students")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }

        [Function("GetStudentById")]
        public HttpResponseData GetStudentById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Students/{id}")] HttpRequestData req,
            Guid id)
        {

            return null;

        }

        [Function("CreateStudent")]
        public HttpResponseData CreateStudent([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Students")] HttpRequestData req)
        {

            return null;

        }

        [Function("UpdateStudent")]
        public HttpResponseData UpdateStudent([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Students/{id}")] HttpRequestData req,
            Guid id)
        {

            return null;

        }

        [Function("DeleteStudent")]
        public HttpResponseData DeleteStudent([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "Students/{id}")] HttpRequestData req,
            Guid id)
        {

            return null;

        }

    }

}
