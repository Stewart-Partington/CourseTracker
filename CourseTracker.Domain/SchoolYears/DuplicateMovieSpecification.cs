using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.SchoolYears
{

    public sealed class DuplicateMovieSpecification : SpecificationBase<List<SchoolYear>>
    {

        private readonly SchoolYear _schoolYear;

        public DuplicateMovieSpecification(SchoolYear schoolYear)
        {
            _schoolYear = schoolYear;
        }

        public override Expression<Func<List<SchoolYear>, bool>> ToExpression()
        {

            return schoolYears => !schoolYears.Any(x => (x.Year == _schoolYear.Year && x.Id != _schoolYear.Id));

        }

    }

}
