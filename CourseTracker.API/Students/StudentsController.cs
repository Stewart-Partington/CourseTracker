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
        public ActionResult<List<StudentListItemModel>> Get()
        {
            return _listQuery.Execute();
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDetailModel> Get(Guid id)
        {
            return _detailQuery.Execute(id);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(CreateStudentModel student)
        {

            Guid result = await _createCommand.ExecuteAsync(student);

            return CreatedAtAction("Get", new { id = result }, result);

        }

        [HttpPut]
        public async Task<ActionResult<HttpResponseMessage>> Update(UpdateStudentModel student)
        {

            await _updateCommand.ExecuteAsync(student);

			return new HttpResponseMessage(HttpStatusCode.OK);

		}

        [HttpDelete("{id}")]
        public async Task<ActionResult<HttpResponseMessage>> Delete(Guid id)
        {

            await _deleteCommand.ExecuteAsync(id);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

    }
}
