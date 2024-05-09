using CourseTracker.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Students
{
	
	public class Student : EntityBase
	{

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string ProgramName { get; set; }

		public List<Course> Courses { get; set; }

	}

}
