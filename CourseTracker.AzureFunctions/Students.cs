using System.Net;
using CourseTracker.AzureFunctions.Models;
using CourseTracker.Domain.Students;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Caching.Memory;
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
        [SqlOutput("[dbo].[Students]", "SqlConnectionString")]
        public async Task<PostStudentModel> CreateStudent([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Students")] HttpRequestData req)
        {

            PostStudentModel student = await req.ReadFromJsonAsync<PostStudentModel>();

            student.Id = Guid.NewGuid();

            return student;

        }

        [Function("UpdateStudent")]
        [SqlOutput("[dbo].[Students]", "SqlConnectionString")]
        public async Task<PostStudentModel> UpdateStudent([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Students")] HttpRequestData req,
            [SqlInput($"SELECT * FROM [dbo].[Students] where Id = @Id", "SqlConnectionString", System.Data.CommandType.Text, "@Id={Query.id}")] IEnumerable<Student> result)
        {

            PostStudentModel student = await req.ReadFromJsonAsync<PostStudentModel>();

            return student;

        }

        [Function("DeleteStudent")]
        [SqlOutput("[dbo].[Students]", "SqlConnectionString")]
        public async Task<Guid> DeleteStudent([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "Students")] HttpRequestData req,
            [SqlInput($"SELECT * FROM [dbo].[Students] where Id = @Id", "SqlConnectionString", System.Data.CommandType.Text, "@Id={Query.id}")] IEnumerable<Student> result)
        {

            // This doesn't work.

            Student student = result.FirstOrDefault();

            return student.Id;

        }

    }

}
