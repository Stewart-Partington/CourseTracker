using CourseTracker.Application.Students.Commands.CreateStudent;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CourseTracker.API.Students
{

    [ApiController]
	[Route("api/[controller]")]
	public class StudentsController : Controller
	{

        private readonly ICreateStudentCommand _createCommand;

		public StudentsController(ICreateStudentCommand createCommand)
        {
            _createCommand = createCommand;
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateStudentModel student)
        {

            _createCommand.Execute(student);

            return new HttpResponseMessage(HttpStatusCode.Created);

        }

    }
}
