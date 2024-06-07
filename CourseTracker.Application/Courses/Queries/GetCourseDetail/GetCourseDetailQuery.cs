using CourseTracker.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
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
				.Include(x => x.Assessments)
				.Select(x => new CourseDetailModel()
				{
					Id = x.Id,
					SchoolYearId = x.SchoolYearId,
					Name = x.Name,
					Semester = x.Semester,
					Grade = x.Grade,
					Notes = x.Notes
				})
				.Single();

			return result;

		}

	}

}
