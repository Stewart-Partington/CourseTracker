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
        public List<AssessmentsListItemModel> Get(Guid studentId, Guid schoolYearId, Guid courseId)
		{
			return _listQuery.Execute(courseId);
		}

        [HttpGet]
        [Route("Students/{studentId}/SchoolYears/{schoolYearId}/Courses/{courseId}/Assessments/{assessmentId}")]
        public AssessmentDetailModel Get(Guid studentId, Guid schoolYearId, Guid courseId, Guid assessmentId)
		{
			return _detailQuery.Execute(assessmentId);
		}

        [HttpPost]
        [Route("Assessments")]
        public async Task<Guid> Post(CreateAssessmentModel assessment)
        {

            Guid result = await _createCommand.Execute(assessment);

            return result;

        }

        [HttpPut]
        [Route("Assessments")]
        public HttpResponseMessage Update(UpdateAssessmentModel assessment)
        {
            _updateCommand.Execute(assessment);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("Assessments/{id}")]
        public HttpResponseMessage Delete(Guid id)
        {
            _deleteCommand.Execute(id);

			return new HttpResponseMessage(HttpStatusCode.OK);

		}

	}

}
