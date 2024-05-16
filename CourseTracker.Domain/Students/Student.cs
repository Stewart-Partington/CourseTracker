using CourseTracker.Domain.SchoolYears;
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
			SchoolYears = new List<SchoolYear>();
		}

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string ProgramName { get; set; }

		public List<SchoolYear> SchoolYears { get; set; }

		public double? Average
		{
			get
			{
				double? result = null;

				if (SchoolYears.Count == 0)
					return result;

				double average = (double)SchoolYears.Sum(x => x.Average);
				result = average / SchoolYears.Count;

                return Math.Round((double)result, 1, MidpointRounding.AwayFromZero);
            }
		}

	}

}
