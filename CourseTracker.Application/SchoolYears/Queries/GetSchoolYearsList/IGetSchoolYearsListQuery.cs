using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList
{
    
    public interface IGetSchoolYearsListQuery
    {

        List<SchoolYearsListItemModel> Execute();

    }

}
