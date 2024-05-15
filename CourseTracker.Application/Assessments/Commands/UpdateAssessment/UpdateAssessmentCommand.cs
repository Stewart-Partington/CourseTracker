using CourseTracker.Application.Assessments.Commands.Factory;
using CourseTracker.Application.Interfaces;
using CourseTracker.Domain.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Commands.UpdateAssessment
{
	
	public class UpdateAssessmentCommand : IUpdateAssessmentCommand
	{

		private readonly IDatabaseService _database;
		private readonly IAssessmentFactory _factory;

		public UpdateAssessmentCommand(IDatabaseService database, IAssessmentFactory factory)
		{
			_database = database;
			_factory = factory;
		}

		public void Execute(UpdateAssessmentModel model)
		{

			Assessment assessment = _factory.Create(model);

			_database.Assessments.Update(assessment);
			_database.Save();

		}

	}

}
