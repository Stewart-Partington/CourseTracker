using System.Net;
using CourseTracker.Domain.Students;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
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

        [Function("GetStudents")]
        public IEnumerable<Student> GetStudents([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route ="Students")] HttpRequestData req,
            [SqlInput("SELECT * FROM [dbo].[Students]", "SqlConnectionString")] IEnumerable<Student> result)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            return result;
        }

        [Function("GetStudentById")]
        public Student GetStudentById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetStudent")] HttpRequestData req,
            [SqlInput($"SELECT * FROM [dbo].[Students] where Id = @Id", "SqlConnectionString", System.Data.CommandType.Text, "@Id={Query.id}")] IEnumerable<Student> result)
        {

            return result.FirstOrDefault();

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
