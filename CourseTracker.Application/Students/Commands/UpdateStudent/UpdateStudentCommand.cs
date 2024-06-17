using CourseTracker.Application.Interfaces;
using CourseTracker.Application.Students.Commands.Factory;
using CourseTracker.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Commands.UpdateStudent
{
	
	public class UpdateStudentCommand : IUpdateStudentCommand
	{

        private readonly IDatabaseService _database;
		private readonly IStudentFactory _factory;

		public UpdateStudentCommand(IDatabaseService database, IStudentFactory factory)
        {
            _database = database;
			_factory = factory;
        }

		public async Task ExecuteAsync(UpdateStudentModel model)
		{

			Student student = _factory.Create(model);

			_database.Students.Update(student);
			await _database.SaveAsync();

		}

	}

}
