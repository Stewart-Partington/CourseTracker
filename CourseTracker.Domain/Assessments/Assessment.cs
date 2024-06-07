using CourseTracker.Domain.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Assessments
{
	
	public class Assessment : EntityBase
	{

        public Assessment()
        {
			Attachments = new List<Attachment>();
        }

        public Guid CourseId { get; set; }

		public AssessmentTypes AssessmentType { get; set;  }

		public string Name { get; set;  }

		public double Grade { get; set; }

		public double Weight { get; set; }

        public string? Notes { get; set; }

        public List<Attachment> Attachments { get; set; }

	}

}
