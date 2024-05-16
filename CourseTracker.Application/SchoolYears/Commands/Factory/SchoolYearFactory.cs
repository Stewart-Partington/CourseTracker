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
    
    public class SchoolYearFactory : ISchoolYearFactory
    {

        public SchoolYear Create(CreateSchoolYearModel model)
        {
            return new SchoolYear()
            {
                StudentId = model.StudentId,
                Index = model.Index,
                Year = model.Year
            };
        }

        public SchoolYear Create(UpdateSchoolYearModel model)
        {
            return new SchoolYear()
            {
                Id = model.Id,
                StudentId = model.StudentId,
                Index = model.Index,
                Year = model.Year
            };
        }

    }

}
