using CourseTracker.Application.Students.Queries.GetStudentDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Queries.GetCourseDetail
{
	
	public interface IGetCourseDetailQuery
	{

		CourseDetailModel Execute(Guid courseId);

	}

}
