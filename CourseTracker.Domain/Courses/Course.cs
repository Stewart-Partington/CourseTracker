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

		public Guid StudentId { get; set; }

		public string Name { get; set; }

		public int Year { get; set; }

		public int Semester { get; set; }

		public List<Assessment> Assessments { get; set; }

		public double Grade { 
			get
			{
				double result = Assessments
					.Where(x => x.Grade != 0 && x.Weight != 0)
					.Sum(x => (x.Grade * (x.Weight / 100)));

				return Math.Round(result, 1, MidpointRounding.AwayFromZero);
			}
		}

	}

}
