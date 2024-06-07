using CourseTracker.Application.Assessments.Commands.CreateAssessment;
using CourseTracker.Application.Assessments.Commands.UpdateAssessment;
using CourseTracker.Domain.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Commands.Factory
{
	
	public class AssessmentFactory : IAssessmentFactory
	{

		public Assessment Create(CreateAssessmentModel model)
		{
			return new Assessment()
			{
				CourseId = model.CourseId,
				AssessmentType = model.AssessmentType,
				Name = model.Name,
				Grade = model.Grade,
				Weight = model.Weight,
				Notes = model.Notes,
			};
		}

		public Assessment Create(UpdateAssessmentModel model)
		{
			return new Assessment()
			{
				Id = model.Id,
				CourseId = model.CourseId,
				AssessmentType = model.AssessmentType,
				Name = model.Name,
				Grade = model.Grade,
				Weight = model.Weight,
				Notes = model.Notes
			};
		}

	}

}
