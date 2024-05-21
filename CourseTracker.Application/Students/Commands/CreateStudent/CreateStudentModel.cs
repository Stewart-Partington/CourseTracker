using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Commands.CreateStudent
{
	
	public class CreateStudentModel
	{

		// This does not belong here. 
		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string ProgramName { get; set; }

	}

}
