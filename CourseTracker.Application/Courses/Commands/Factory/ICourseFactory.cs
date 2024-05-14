using CourseTracker.Application.Courses.Commands.CreateCourse;
using CourseTracker.Application.Courses.Commands.UpdateCourse;
using CourseTracker.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Commands.Factory
{

    public interface ICourseFactory
	{

		Course Create(CreateCourseModel model);

		Course Create(UpdateCourseModel model);

	}

}
