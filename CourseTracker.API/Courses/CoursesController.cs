using CourseTracker.Application.Courses.Commands.CreateCourse;
using CourseTracker.Application.Courses.Commands.DeleteCourse;
using CourseTracker.Application.Courses.Commands.UpdateCourse;
using CourseTracker.Application.Courses.Queries.GetCourseDetail;
using CourseTracker.Application.Courses.Queries.GetCoursesList;
using CourseTracker.Domain.SchoolYears;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CourseTracker.API.Courses
{

    [Route("api/")]
	[ApiController]
	public class CoursesController : ControllerBase
	{

		private readonly IGetCourseListQuery _listQuery;
		private readonly IGetCourseDetailQuery _detailQuery;
		private readonly ICreateCourseCommand _createCommand;
		private readonly IUpdateCourseCommand _updateCommand;
		private readonly IDeleteCourseCommand _deleteCommand;

		public CoursesController(IGetCourseListQuery listQuery, IGetCourseDetailQuery detailQuery, ICreateCourseCommand createCommand,
			IUpdateCourseCommand updateCommand, IDeleteCourseCommand deleteCommand)
		{
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
			_deleteCommand = deleteCommand;
		}

        [HttpGet]
		[Route("Students/{studentId}/SchoolYears/{schoolYearId}/Courses")]
		public ActionResult<List<CoursesListItemModel>> Get(Guid studentId, Guid schoolYearId)
		{
			return _listQuery.Execute(schoolYearId);
		}

		[HttpGet]
        [Route("Students/{studentId}/SchoolYears/{schoolYearId}/Courses/{courseId}")]
        public ActionResult<CourseDetailModel> Get(Guid studentId, Guid schoolYearId, Guid courseId)
		{
			return _detailQuery.Execute(courseId);
		}

        [HttpPost]
        [Route("Courses")]
        public async Task<ActionResult<Guid>> Post(CreateCourseModel course)
        {
            Guid result = await _createCommand.ExecuteAsync(course);

            return Created($"Students/{course.StudentId}/SchoolYears/{course.SchoolYearId}/Courses/{result}", result);
        }

		[HttpPut]
		[Route("Courses")]
		public async Task<ActionResult<HttpResponseMessage>> Update(UpdateCourseModel course)
		{
			await _updateCommand.ExecuteAsync(course);
			return new HttpResponseMessage(HttpStatusCode.OK);
		}

		[HttpDelete]
		[Route("Courses/{id}")]
		public async Task <ActionResult<HttpResponseMessage>> Delete(Guid id)
		{

			await _deleteCommand.ExecuteAsync(id);

			return new HttpResponseMessage(HttpStatusCode.OK);

		}

	}

}
