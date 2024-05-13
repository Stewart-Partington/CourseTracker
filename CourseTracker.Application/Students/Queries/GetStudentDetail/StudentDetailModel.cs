using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Queries.GetStudentDetail
{
	
	public class StudentDetailModel
	{

		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string ProgramName { get; set; }

	}

}
