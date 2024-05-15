using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Commands.DeleteAssessment
{
	
	public interface IDeleteAssessmentCommand
	{

		void Execute(Guid assessmentId);

	}

}
