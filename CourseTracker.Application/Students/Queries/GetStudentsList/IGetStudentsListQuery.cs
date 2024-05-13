using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Queries.GetStudentsList
{
	
	public interface IGetStudentsListQuery
	{

		List<StudentListItemModel> Execute();

	}

}
