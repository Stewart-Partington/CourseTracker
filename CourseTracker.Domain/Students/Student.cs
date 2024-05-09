using CourseTracker.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Students
{
	
	public class Student : EntityBase
	{

		public Student()
		{
			Courses = new List<Course>();
		}

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string ProgramName { get; set; }

		public List<Course> Courses { get; set; }

		public double GetAverage(int? year = null)
		{
			// Todo: Associated tests are green. Need to refactor.

			double result = -1;

			if (year == null)
			{
				var coursesByYear = Courses.GroupBy(x => x.Year).ToList();
				double average = 0;
				foreach (var course in coursesByYear)
					average = average + course.Sum(x => (x.Grade / course.Count()));
				result = average / coursesByYear.Count;
			}
			else
			{
				int courseCount = Courses.Where(x => x.Year == (int)year).Count();
				result = Courses
					.Where(x => x.Year == (int)year)
					.Sum(x => (x.Grade / courseCount));
			}

			return Math.Round(result, 1, MidpointRounding.AwayFromZero);

		}

	}

}
