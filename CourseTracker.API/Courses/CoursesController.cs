using CourseTracker.Application.Courses.Commands.CreateCourse;
using CourseTracker.Application.Courses.Commands.DeleteCourse;
using CourseTracker.Application.Courses.Commands.UpdateCourse;
using CourseTracker.Application.Courses.Queries.GetCourseDetail;
using CourseTracker.Application.Courses.Queries.GetCoursesList;
using CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.Application.Students.Queries.GetStudentsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CourseTracker.API.Courses
{
	
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController : ControllerBase
	{

		private readonly IGetCoursesListQuery _listQuery;
		private readonly IGetCourseDetailQuery _detailQuery;
		private readonly ICreateCourseCommand _createCommand;
		private readonly IUpdateCourseCommand _updateCommand;
		private readonly IDeleteCourseCommand _deleteCommand;

        public CoursesController(IGetCoursesListQuery listQuery, IGetCourseDetailQuery detailQuery, ICreateCourseCommand createCommand,
			IUpdateCourseCommand updateCommand, IDeleteCourseCommand deleteCommand)
        {
			_listQuery = listQuery;
			_detailQuery = detailQuery;
			_createCommand = createCommand;
			_updateCommand = updateCommand;
			_deleteCommand = deleteCommand;
		}

		[HttpGet]
		public List<CoursesListItemModel> Get()
		{
			return _listQuery.Execute();
		}

		[HttpGet("{id}")]
		public CourseDetailModel Get(Guid id)
		{
			return _detailQuery.Execute(id);
		}

        [HttpPost]
        public async Task<IActionResult> Post(CreateCourseModel course)
        {

            Guid id = await _createCommand.Execute(course);

            return CreatedAtAction("Get", new { id = id });

        }

        [HttpPut]
		public HttpResponseMessage Update(UpdateCourseModel course)
		{

			_updateCommand.Execute(course);

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
