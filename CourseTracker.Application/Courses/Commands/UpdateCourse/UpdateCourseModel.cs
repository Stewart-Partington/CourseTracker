using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Commands.UpdateCourse
{
	
	public class UpdateCourseModel
	{

		public Guid Id { get; set; }

		public Guid SchoolYearId { get; set; }

		public string Name { get; set; }

		public int Year { get; set; }

		public int Semester { get; set; }

        public string? Notes { get; set; }

    }

}
