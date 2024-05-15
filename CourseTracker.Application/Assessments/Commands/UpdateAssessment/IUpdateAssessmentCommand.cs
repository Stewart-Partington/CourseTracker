using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Commands.UpdateAssessment
{
	
	public interface IUpdateAssessmentCommand
	{

		void Execute(UpdateAssessmentModel model);

	}

}
