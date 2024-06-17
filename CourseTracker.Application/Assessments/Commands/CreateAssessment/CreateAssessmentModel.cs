using CourseTracker.Domain.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Commands.CreateAssessment
{
	
	public class CreateAssessmentModel
	{

		public Guid StudentId { get; set; }

		public Guid SchoolYearId { get; set; }

		public Guid CourseId { get; set; }

		public AssessmentTypes AssessmentType { get; set; }

		public string Name { get; set; }

		public double Grade { get; set; }

		public double Weight { get; set; }

        public string? Notes { get; set; }

    }

}
