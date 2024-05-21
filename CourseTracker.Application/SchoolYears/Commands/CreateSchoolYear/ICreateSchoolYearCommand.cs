using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear
{
    
    public interface ICreateSchoolYearCommand
    {

        Task<Guid> Execute(CreateSchoolYearModel model);

    }

}
