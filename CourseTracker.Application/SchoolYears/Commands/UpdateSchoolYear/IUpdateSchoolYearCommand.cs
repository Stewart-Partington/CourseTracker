using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.SchoolYears.Commands.UpdateSchoolYear
{
    
    public interface IUpdateSchoolYearCommand
    {

        void Execute(UpdateSchoolYearModel model);

    }

}
