using CourseTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Queries.GetCourseDetail
{
	
	public class GetCourseDetailQuery : IGetCourseDetailQuery
	{

		private readonly IDatabaseService _database;

		public GetCourseDetailQuery(IDatabaseService database)
		{
			_database = database;
		}

		public CourseDetailModel Execute(Guid courseId)
		{

			var result = _database.Courses
				.Where(x => x.Id == courseId)
				.Select(x => new CourseDetailModel()
				{
					Id = x.Id,
					StudentId = x.StudentId,
					Name = x.Name,
					Year = x.Year,
					Semester = x.Semester,
					Grade = x.Grade
				})
				.Single();

			return result;

		}

	}

}
