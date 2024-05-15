using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Queries.GetAssementDetail
{
	
	public interface IGetAssessmentDetailQuery
	{

		AssessmentDetailModel Execute(Guid courseId);

	}

}
