using CourseTracker.Application.Courses.Queries.GetCourseDetail;
using CourseTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Queries.GetAssementDetail
{
	
	public class GetAssessmentDetailQuery : IGetAssessmentDetailQuery
	{

		private readonly IDatabaseService _database;

		public GetAssessmentDetailQuery(IDatabaseService database)
		{
			_database = database;
		}

		public AssessmentDetailModel Execute(Guid assessmentId)
		{

			var result = _database.Assessments
				.Where(x => x.Id == assessmentId)
				.Select(x => new AssessmentDetailModel()
				{
					Id = x.Id,
					CourseId = x.CourseId,
					AssessmentType = x.AssessmentType,
					Name = x.Name,
					Grade = x.Grade,
					Weight = x.Weight,
					Notes = x.Notes
				})
				.Single();

			return result;

		}

	}

}
