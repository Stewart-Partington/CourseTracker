using CourseTracker.Domain.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Queries.GetAssessmentList
{
	
	public class AssessmentsListItemModel
	{

		public Guid Id { get; set; }

		public Guid CourseId { get; set; }

		public AssessmentTypes AssessmentType { get; set; }

		public string AssessmentTypeDescription { get; set; }

		public string Name { get; set; }

		public double Grade { get; set; }

		public double Weight { get; set; }

	}

}
