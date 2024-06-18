using CourseTracker.Application.Assessments.Commands.CreateAssessment;
using CourseTracker.Application.Assessments.Commands.DeleteAssessment;
using CourseTracker.Application.Assessments.Commands.UpdateAssessment;
using CourseTracker.Application.Assessments.Queries.GetAssementDetail;
using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.Application.Courses.Commands.CreateCourse;
using CourseTracker.Domain.Courses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CourseTracker.API.Assessments
{

    [Route("api/")]
    [ApiController]
	public class AssessmentsController : ControllerBase
	{

		private readonly IGetAssessmentsListQuery _listQuery;
		private readonly IGetAssessmentDetailQuery _detailQuery;
		private readonly ICreateAssessmentCommand _createCommand;
		private readonly IUpdateAssessmentCommand _updateCommand;
		private readonly IDeleteAssessmentCommand _deleteCommand;

		public AssessmentsController(IGetAssessmentsListQuery listQuery, IGetAssessmentDetailQuery detailQuery, ICreateAssessmentCommand createCommand,
			IUpdateAssessmentCommand updateCommand, IDeleteAssessmentCommand deleteCommand)
		{
			_listQuery = listQuery;
			_detailQuery = detailQuery;
			_createCommand = createCommand;
			_updateCommand = updateCommand;
			_deleteCommand = deleteCommand;
		}

        [HttpGet]
        [Route("Students/{studentId}/SchoolYears/{schoolYearId}/Courses/{courseId}/Assessments")]
        public ActionResult<List<AssessmentsListItemModel>> Get(Guid studentId, Guid schoolYearId, Guid courseId)
		{
			return _listQuery.Execute(courseId);
		}

        [HttpGet]
        [Route("Students/{studentId}/SchoolYears/{schoolYearId}/Courses/{courseId}/Assessments/{assessmentId}")]
        public ActionResult<AssessmentDetailModel> Get(Guid studentId, Guid schoolYearId, Guid courseId, Guid assessmentId)
		{
			return _detailQuery.Execute(assessmentId);
		}

        [HttpPost]
        [Route("Assessments")]
        public async Task<ActionResult<Guid>> Post(CreateAssessmentModel assessment)
        {

            Guid result = await _createCommand.ExecuteAsync(assessment);

            return Created($"Students/{assessment.StudentId}/SchoolYears/{assessment.SchoolYearId}/Courses/{assessment.CourseId}/Assessments/{result}", result);

        }

        [HttpPut]
        [Route("Assessments")]
        public async Task<ActionResult<HttpResponseMessage>> Update(UpdateAssessmentModel assessment)
        {
            await _updateCommand.ExecuteAsync(assessment);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("Assessments/{id}")]
        public async Task<ActionResult<HttpResponseMessage>> Delete(Guid id)
        {
            await _deleteCommand.ExecuteAsync(id);

			return new HttpResponseMessage(HttpStatusCode.OK);

		}

	}

}
