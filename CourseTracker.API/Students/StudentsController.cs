using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.Application.Students.Queries.GetStudentsList;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CourseTracker.API.Students
{

    [ApiController]
	[Route("api/[controller]")]
	public class StudentsController : Controller
	{

        private readonly IGetStudentsListQuery _listQuery;
        private readonly IGetStudentDetailQuery _detailQuery;
        private readonly ICreateStudentCommand _createCommand;

		public StudentsController(IGetStudentsListQuery listQuery, IGetStudentDetailQuery detailQuery, ICreateStudentCommand createCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
        }

        [HttpGet]
        public List<StudentListItemModel> Get()
        {
            return _listQuery.Execute();
        }

        [HttpGet("{id}")]
        public StudentDetailModel Get(Guid id)
        {
            return _detailQuery.Execute(id);
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateStudentModel student)
        {

            _createCommand.Execute(student);

            return new HttpResponseMessage(HttpStatusCode.Created);

        }

    }
}
