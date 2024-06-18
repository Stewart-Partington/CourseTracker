using CourseTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Commands.DeleteAssessment
{
	
	public class DeleteAssessmentCommand : IDeleteAssessmentCommand
	{

		private readonly IDatabaseService _database;

		public DeleteAssessmentCommand(IDatabaseService database)
		{
			_database = database;
		}

		public async Task ExecuteAsync(Guid assesssmentId)
		{

			var assessment = _database.Assessments.Find(assesssmentId);

			_database.Assessments.Remove(assessment);
			await _database.SaveAsync();

		}

	}

}
