using CourseTracker.Domain.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Courses
{
	
	public class Course : EntityBase
	{

		public Course()
		{
			Assessments = new List<Assessment>();
		}

		public Guid SchoolYearId { get; set; }

		public string Name { get; set; }

		public int? Semester { get; set; }

		public List<Assessment> Assessments { get; set; }

		public double Grade { 
			get
			{
				double result = 0;
				double totalGrades = Assessments
                    .Sum(x => (x.Grade * (x.Weight / 100)));
                double totalWeight = Assessments
					.Sum(x => x.Weight);

				if (totalGrades != 0 && totalWeight != 0)
					result = (totalGrades / totalWeight) * 100;

				return Math.Round(result, 1, MidpointRounding.AwayFromZero);
			}
		}

	}

}
