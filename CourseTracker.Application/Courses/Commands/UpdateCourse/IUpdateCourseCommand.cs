using CourseTracker.Application.Students.Commands.UpdateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Commands.UpdateCourse
{
	
	public interface IUpdateCourseCommand
	{

		Task ExecuteAsync(UpdateCourseModel model);

	}

}
