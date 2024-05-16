using CourseTracker.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.SchoolYears
{
    
    public class SchoolYear : EntityBase
    {

        public SchoolYear()
        {
            Courses = new List<Course>();
        }

        public Guid StudentId { get; set;  }

        public int Index { get; set; }

        public int Year { get; set; }

        public List<Course> Courses { get; set; }

        public double? Average
        {
            get
            {
                double? result = null;

                if (Courses.Count == 0)
                    return result;

                result = Courses.Sum(x => (x.Grade / Courses.Count()));

                return Math.Round((double)result, 1, MidpointRounding.AwayFromZero);
            }
        }

    }

}
