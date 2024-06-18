using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Commands.DeleteCourse
{
	
	public interface IDeleteCourseCommand
	{

        Task ExecuteAsync(Guid courseId);

	}

}
