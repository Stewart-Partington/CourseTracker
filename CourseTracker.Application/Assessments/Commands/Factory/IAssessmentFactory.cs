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
	
	public interface IAssessmentFactory
	{

		Assessment Create(CreateAssessmentModel model);

		Assessment Create(UpdateAssessmentModel model);

	}

}
