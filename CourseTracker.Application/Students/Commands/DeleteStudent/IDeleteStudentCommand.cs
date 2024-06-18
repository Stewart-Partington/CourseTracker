using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Commands.DeleteStudent
{
	
	public interface IDeleteStudentCommand
	{

		Task ExecuteAsync(Guid studentId);

	}

}
