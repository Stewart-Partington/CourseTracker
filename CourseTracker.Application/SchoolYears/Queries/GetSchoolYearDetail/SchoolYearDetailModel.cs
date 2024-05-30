using CourseTracker.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.SchoolYears.Queries.GetSchoolYearDetail
{
    
    public class SchoolYearDetailModel
    {

        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public int Index { get; set; }

        public int Year { get; set; }

        public double? Average { get; set; }

    }

}
