using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Commands.Factory
{
	
	public class StudentFactory : IStudentFactory
	{

		public Student Create(CreateStudentModel createStudentModel)
		{
			return new Student()
			{
				FirstName = createStudentModel.FirstName,
				LastName = createStudentModel.LastName,
				ProgramName = createStudentModel.ProgramName
			};
		}

	}

}
