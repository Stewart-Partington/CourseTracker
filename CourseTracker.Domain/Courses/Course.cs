using CourseTracker.Domain.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Courses
{
	
	public class Course : EntityBase
	{

		public string Name { get; set; }

		public int Year { get; set; }

		public int Semester { get; set; }

		public List<Assessment> Assessments { get; set; }

	}

}
