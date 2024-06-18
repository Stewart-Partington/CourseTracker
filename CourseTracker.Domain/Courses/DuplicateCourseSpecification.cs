using CourseTracker.Domain.SchoolYears;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Courses
{
    
    public class DuplicateCourseSpecification : SpecificationBase<List<Course>>
    {

        private Course _course;

        public DuplicateCourseSpecification(Course course)
        {
            _course = course;
        }

        public override Expression<Func<List<Course>, bool>> ToExpression()
        {

            return courses => !courses.Any(x => (x.Name == _course.Name && x.Id != _course.Id));

        }

    }

}
