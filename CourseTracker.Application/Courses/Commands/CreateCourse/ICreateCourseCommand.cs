using CourseTracker.Application.Students.Commands.CreateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Commands.CreateCourse
{

    public interface ICreateCourseCommand
    {

        Guid Execute(CreateCourseModel model);

    }

}
