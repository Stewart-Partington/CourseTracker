using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Queries.GetCoursesList
{
	
	public class CoursesListItemModel
	{

		public Guid Id { get; set; }

		public Guid SchoolYearId { get; set; }

		public string Name { get; set; }

		public int Semester { get; set; }

		//public List<Assessment> Assessments { get; set; S

		public double Grade { get; set; }

	}

}
