using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Assessments
{
    
    public class CumulativeAssessmentWeightSpecification : SpecificationBase<List<Assessment>>
    {

        public CumulativeAssessmentWeightSpecification()
        {
        }

        public override Expression<Func<List<Assessment>, bool>> ToExpression()
        {

            return assessments => assessments.Sum(x => x.Weight) <= 100;

        }

    }

}
