using CourseTracker.Application.Assessments.Commands.Factory;
using CourseTracker.Application.Interfaces;
using CourseTracker.Domain.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Commands.CreateAssessment
{
	
	public class CreateAssessmentCommand : ICreateAssessmentCommand
	{

		private readonly IDatabaseService _database;
		private readonly IAssessmentFactory _factory;

		public CreateAssessmentCommand(IDatabaseService database, IAssessmentFactory factory)
		{
			_database = database;
			_factory = factory;
		}

		public async Task<Guid> ExecuteAsync(CreateAssessmentModel model)
		{

			Guid result = Guid.Empty;
			Assessment assessment = _factory.Create(model);

			result = await _database.InsertAsync<Assessment>(assessment);

			return result;

		}

	}

}
