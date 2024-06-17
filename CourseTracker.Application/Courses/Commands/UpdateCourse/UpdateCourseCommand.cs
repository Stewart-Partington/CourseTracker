using CourseTracker.Application.Courses.Commands.Factory;
using CourseTracker.Application.Interfaces;
using CourseTracker.Application.Students.Commands.Factory;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Domain.Courses;
using CourseTracker.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Commands.UpdateCourse
{
	
	public class UpdateCourseCommand : IUpdateCourseCommand
	{

		private readonly IDatabaseService _database;
		private readonly ICourseFactory _factory;

		public UpdateCourseCommand(IDatabaseService database, ICourseFactory factory)
		{
			_database = database;
			_factory = factory;
		}

		public async Task ExecuteAsync(UpdateCourseModel model)
		{

			Course course = _factory.Create(model);

			_database.Courses.Update(course);
			await _database.SaveAsync();

		}

	}

}
