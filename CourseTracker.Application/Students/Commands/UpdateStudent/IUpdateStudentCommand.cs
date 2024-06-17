using CourseTracker.Application.Students.Commands.CreateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Commands.UpdateStudent
{
	
	public interface IUpdateStudentCommand
	{

		Task ExecuteAsync(UpdateStudentModel model);

	}

}
