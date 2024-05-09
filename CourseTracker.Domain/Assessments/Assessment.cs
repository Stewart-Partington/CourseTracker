using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Assessments
{
	
	public class Assessment : EntityBase
	{

		AssessmentTypes AssessmentType { get; set;  }

		public string Name { get; set;  }

		public double Grade { get; set; }

		public double Weight { get; set; }

	}

}
