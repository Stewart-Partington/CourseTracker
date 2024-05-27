using CourseTracker.Application.Courses.Queries.GetCoursesList;
using CourseTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Queries.GetAssessmentList
{
	
	public  class GetAssessmentsListQuery : IGetAssessmentsListQuery
	{

		private readonly IDatabaseService _database;

		public GetAssessmentsListQuery(IDatabaseService database)
		{
			_database = database;
		}

		public List<AssessmentsListItemModel> Execute(Guid courseId)
		{

			var result = _database.Assessments
				.Where(x => x.CourseId == courseId)
				.Select(x => new AssessmentsListItemModel()
				{
					Id = x.Id,
					CourseId = x.CourseId,
					AssessmentType = x.AssessmentType,
					Name = x.Name,
					Grade = x.Grade,
					Weight = x.Weight
				});

			return result.ToList();

		}

	}

}
