using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList
{
    
    public class SchoolYearsListItemModel
    {

        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public int Index { get; set; }

        public int Year { get; set; }

    }

}
