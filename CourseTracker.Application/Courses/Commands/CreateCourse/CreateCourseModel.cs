using CourseTracker.Domain.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Commands.CreateCourse
{

    public class CreateCourseModel
    {

		public Guid StudentId { get; set; }

		public string Name { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        public double Grade { get; set; }

    }

}
