using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Queries.GetStudentsList
{
	
	public class StudentListItemModel
	{

		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string ProgramName { get; set; }

		public double? Average { get; set; }

	}

}
