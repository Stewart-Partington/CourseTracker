using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Assessments
{
    
    public class DuplicateAssessmentSpecification : SpecificationBase<List<Assessment>>
    {

        private Assessment _assessment;

        public DuplicateAssessmentSpecification(Assessment assessment)
        {
            _assessment = assessment;
        }

        public override Expression<Func<List<Assessment>, bool>> ToExpression()
        {

            return assessments => !assessments.Any(x => ((x.Name == _assessment.Name && x.AssessmentType == _assessment.AssessmentType) && x.Id != _assessment.Id));

        }

    }

}
