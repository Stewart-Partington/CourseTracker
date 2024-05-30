using CourseTracker.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Queries.GetStudentsList
{
	
	
	public class GetStudentsListQuery : IGetStudentsListQuery
	{

		private readonly IDatabaseService _database;

        public GetStudentsListQuery(IDatabaseService database)
        {
			_database = database;
        }

		public List<StudentListItemModel> Execute()
		{

			var result = _database.Students
				.Include(x => x.SchoolYears)
				.ThenInclude(x => x.Courses)
				.ThenInclude(x => x.Assessments)
				.Select(x => new StudentListItemModel()
				{
					Id = x.Id,
					FirstName = x.FirstName,
					LastName = x.LastName,
					ProgramName = x.ProgramName,
					Average = x.Average
				});

			return result.ToList();

		}

    }

}
