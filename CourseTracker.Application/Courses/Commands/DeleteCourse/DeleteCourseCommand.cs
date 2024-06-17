using CourseTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Commands.DeleteCourse
{
	
	public class DeleteCourseCommand : IDeleteCourseCommand
	{

		private readonly IDatabaseService _database;

		public DeleteCourseCommand(IDatabaseService database)
		{
			_database = database;
		}

		public async Task ExecuteAsync(Guid courseId)
		{

			var course = _database.Courses.Find(courseId);

			_database.Courses.Remove(course);
			_database.SaveAsync();

		}

	}

}
