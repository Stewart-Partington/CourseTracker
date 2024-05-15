using CourseTracker.Application.Courses.Queries.GetCoursesList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Queries.GetAssessmentList
{
	
	public interface IGetAssessmentsListQuery
	{

		List<AssessmentsListItemModel> Execute();

	}

}
