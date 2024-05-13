using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Queries.GetStudentDetail
{
	
	public interface IGetStudentDetailQuery
	{

		StudentDetailModel Execute(Guid studentId);

	}

}
