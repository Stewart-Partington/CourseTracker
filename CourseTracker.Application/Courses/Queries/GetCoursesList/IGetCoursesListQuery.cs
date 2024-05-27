using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Queries.GetCoursesList
{
	
	public interface IGetCoursesListQuery
	{

		List<CoursesListItemModel> Execute(Guid schoolYearId);

	}

}
