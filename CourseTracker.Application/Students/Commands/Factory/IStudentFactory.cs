using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Commands.Factory
{
    
    public interface IStudentFactory
    {

        Student Create(CreateStudentModel createStudentModel);
        Student Create(UpdateStudentModel updateStudentModel);

    }

}
