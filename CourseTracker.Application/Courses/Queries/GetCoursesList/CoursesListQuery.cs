using CourseTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Queries.GetCoursesList
{
	
	public class CoursesListQuery : IGetCoursesListQuery
	{

		private readonly IDatabaseService _database;

		public CoursesListQuery(IDatabaseService database)
		{
			_database = database;
		}

		public List<CoursesListItemModel> Execute()
		{

			var result = _database.Courses
				.Select(x => new CoursesListItemModel()
				{
					Id = x.Id,
					StudentId = x.StudentId,
					Name = x.Name,
					Year = x.Year,
					Semester = x.Semester,
					Grade = x.Grade
				});

			return result.ToList();

		}

	}

}
