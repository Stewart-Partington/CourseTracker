using CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.UpdateSchoolYear;
using CourseTracker.Domain.SchoolYears;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.SchoolYears.Commands.Factory
{
    
    public interface ISchoolYearFactory
    {

        SchoolYear Create(CreateSchoolYearModel model);
        SchoolYear Create(UpdateSchoolYearModel model);

    }

}
