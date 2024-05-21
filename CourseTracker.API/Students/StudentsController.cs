using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Commands.DeleteStudent;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.Application.Students.Queries.GetStudentsList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Linq.Expressions;
using System.Net;

namespace CourseTracker.API.Students
{

    [ApiController]
	[Route("api/[controller]")]
	public class StudentsController : ControllerBase
	{

        private readonly IGetStudentsListQuery _listQuery;
        private readonly IGetStudentDetailQuery _detailQuery;
        private readonly ICreateStudentCommand _createCommand;
        private readonly IUpdateStudentCommand _updateCommand;
        private readonly IDeleteStudentCommand _deleteCommand;

		public StudentsController(IGetStudentsListQuery listQuery, IGetStudentDetailQuery detailQuery, ICreateStudentCommand createCommand,
            IUpdateStudentCommand updateCommand, IDeleteStudentCommand deleteCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
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
        public async Task<IActionResult> Post(CreateStudentModel student)
        {

            Guid id = await _createCommand.Execute(student);

            student.Id = id;

            return CreatedAtAction("Get", new { id = id }, student);

        }

        [HttpPut]
        public HttpResponseMessage Update(UpdateStudentModel student)
        {

            _updateCommand.Execute(student);

			return new HttpResponseMessage(HttpStatusCode.OK);

		}

        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(Guid id)
        {

            _deleteCommand.Execute(id);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

    }
}
