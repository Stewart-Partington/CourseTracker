using CourseTracker.Domain.Assessments;
using CourseTracker.Domain.Courses;
using CourseTracker.Domain.SchoolYears;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Students
{
	
	[TestFixture]
	public class StudentTests
	{

		private Student _student;

		[SetUp]
		public void SetUp()
		{
			_student = new Student();
		}

		[Test]
		public void GetAverageForAllYears()
		{

			double? average;
			SchoolYear schoolYear;
			Course course;

			// 2023
			schoolYear = new SchoolYear() { Index = 1, Year = 2023 };
			_student.SchoolYears.Add(schoolYear);
			course = new Course();
			course.Assessments.Add(new Assessment() { Grade = 100, Weight = 50 });
			course.Assessments.Add(new Assessment() { Grade = 50, Weight = 50 });
            schoolYear.Courses.Add(course);
			course = new Course();
			course.Assessments.Add(new Assessment() { Grade = 100, Weight = 75 });
			course.Assessments.Add(new Assessment() { Grade = 50, Weight = 25 });
            schoolYear.Courses.Add(course);

			// 2024
			course = new Course();
            _student.SchoolYears.Add(schoolYear);
            course.Assessments.Add(new Assessment() { Grade = 66.666, Weight = 50 });
			course.Assessments.Add(new Assessment() { Grade = 33.333, Weight = 50 });
            schoolYear.Courses.Add(course);
			course = new Course();
			course.Assessments.Add(new Assessment() { Grade = 66.666, Weight = 75 });
			course.Assessments.Add(new Assessment() { Grade = 33.333, Weight = 25 });
            schoolYear.Courses.Add(course);

			Assert.That(_student.Average, Is.EqualTo(67.7));

		}

	}

}
