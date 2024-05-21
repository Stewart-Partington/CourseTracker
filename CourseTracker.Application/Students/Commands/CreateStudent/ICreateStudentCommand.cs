using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Commands.CreateStudent
{
	
	public interface ICreateStudentCommand
	{

		Task<Guid> Execute(CreateStudentModel model);

	}

}
