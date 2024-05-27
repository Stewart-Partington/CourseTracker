using CourseTracker.Application.Courses.Commands.CreateCourse;
using CourseTracker.Application.Courses.Commands.DeleteCourse;
using CourseTracker.Application.Courses.Commands.UpdateCourse;
using CourseTracker.Application.Courses.Queries.GetCourseDetail;
using CourseTracker.Application.Courses.Queries.GetCoursesList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CourseTracker.API.Courses
{

    [Route("api/")]
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
        [Route("SchoolYears/{schoolYearId}/Courses")]
        public List<CoursesListItemModel> Get(Guid schoolYearId)
		{
			return _listQuery.Execute(schoolYearId);
		}

		[HttpGet]
        [Route("Students/{studentId}/SchoolYears/{schoolYearId}/Courses/{courseId}")]
        public CourseDetailModel Get(Guid studentId, Guid schoolYearId, Guid courseId)
		{
			return _detailQuery.Execute(courseId);
		}

        [HttpPost]
        [Route("Courses")]
        public async Task<IActionResult> Post(CreateCourseModel course)
        {

            Guid courseId = await _createCommand.Execute(course);

            return CreatedAtAction("Get", new { studentId = course.StudentId, schoolYearId = course.SchoolYearId, courseId = courseId }, courseId);
        }

        [HttpPut]
        [Route("Courses")]
        public HttpResponseMessage Update(UpdateCourseModel course)
        {
            _updateCommand.Execute(course);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

		[HttpDelete]
        [Route("Courses/{id}")]
        public HttpResponseMessage Delete(Guid id)
		{

			_deleteCommand.Execute(id);

			return new HttpResponseMessage(HttpStatusCode.OK);

		}

	}

}
