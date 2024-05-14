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

    public class CourseFactory
	{

		public Course Create(CreateCourseModel model)
		{
			return new Course()
			{
				StudentId = model.StudentId,
				Name = model.Name,
				Year = model.Year,
				Semester = model.Semester,
				//Grade = model.Grade
			};
		}

		public Course Create(UpdateCourseModel model)
		{
			return new Course()
			{
				Id = model.Id,
				StudentId = model.StudentId,
				Name = model.Name,
				Year = model.Year,
				Semester = model.Semester,
			};
		}

	}

}
