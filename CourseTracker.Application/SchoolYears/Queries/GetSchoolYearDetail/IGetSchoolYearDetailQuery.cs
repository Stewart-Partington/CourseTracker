using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.SchoolYears.Queries.GetSchoolYearDetail
{
    
    public interface IGetSchoolYearDetailQuery
    {

        SchoolYearDetailModel Execute(Guid schoolYearId);

    }

}
