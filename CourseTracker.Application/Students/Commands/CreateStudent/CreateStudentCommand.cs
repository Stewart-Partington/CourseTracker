using CourseTracker.Application.Interfaces;
using CourseTracker.Application.Students.Commands.Factory;
using CourseTracker.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Commands.CreateStudent
{

	public class CreateStudentCommand : ICreateStudentCommand
	{
		
		private readonly IDatabaseService _database;
		private readonly IStudentFactory _factory;

        public CreateStudentCommand(IDatabaseService database, IStudentFactory factory)
        {
			_database = database;
			_factory = factory;
        }

        public async Task<Guid> ExecuteAsync(CreateStudentModel model)
		{
			
			Guid result = Guid.Empty;
			Student student = _factory.Create(model);

			result = await _database.InsertAsync<Student>(student);

			return result;

		}

	}

}

