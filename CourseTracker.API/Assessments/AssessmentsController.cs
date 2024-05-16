using CourseTracker.Application.Assessments.Commands.CreateAssessment;
using CourseTracker.Application.Assessments.Commands.DeleteAssessment;
using CourseTracker.Application.Assessments.Commands.UpdateAssessment;
using CourseTracker.Application.Assessments.Queries.GetAssementDetail;
using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.Application.Courses.Commands.CreateCourse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CourseTracker.API.Assessments
{
	
	[Route("api/[controller]")]
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
		public List<AssessmentsListItemModel> Get()
		{
			return _listQuery.Execute();
		}

		[HttpGet("{id}")]
		public AssessmentDetailModel Get(Guid id)
		{
			return _detailQuery.Execute(id);
		}

        [HttpPost]
        public IActionResult Post(CreateAssessmentModel assessment)
        {

            Guid id = _createCommand.Execute(assessment);

            return CreatedAtAction("Get", new { id = id });

        }

        [HttpPut]
		public HttpResponseMessage Update(UpdateAssessmentModel assessment)
		{

			_updateCommand.Execute(assessment);

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
