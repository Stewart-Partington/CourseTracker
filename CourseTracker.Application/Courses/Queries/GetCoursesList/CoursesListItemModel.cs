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

		public Guid StudentId { get; set; }

		public string Name { get; set; }

		public int Year { get; set; }

		public int Semester { get; set; }

		//public List<Assessment> Assessments { get; set; }

		public double Grade { get; set; }

	}

}
