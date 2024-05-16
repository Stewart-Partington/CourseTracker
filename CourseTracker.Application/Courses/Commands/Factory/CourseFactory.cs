using CourseTracker.Application.Courses.Commands.CreateCourse;
using CourseTracker.Application.Courses.Commands.UpdateCourse;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Commands.Factory
{

    public class CourseFactory : ICourseFactory
	{

		public Course Create(CreateCourseModel model)
		{
			return new Course()
			{
				SchoolYearId = model.SchoolYearId,
				Name = model.Name,
				Semester = model.Semester,
			};
		}

		public Course Create(UpdateCourseModel model)
		{
			return new Course()
			{
				Id = model.Id,
				SchoolYearId = model.SchoolYearId,
				Name = model.Name,
				Semester = model.Semester,
			};
		}

	}

}
