using CourseTracker.Domain.Assessments;
using CourseTracker.Domain.Courses;
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
		public void GetAverageFor1Year()
		{

			double average;
			Course course;

			// 2023
			course = new Course() { Year = 2023 };
			course.Assessments.Add(new Assessment() { Grade = 100, Weight = 50 });
			course.Assessments.Add(new Assessment() { Grade = 50, Weight = 50 });
			_student.Courses.Add(course);
			course = new Course() { Year = 2023 };
			course.Assessments.Add(new Assessment() { Grade = 100, Weight = 75 });
			course.Assessments.Add(new Assessment() { Grade = 50, Weight = 25 });
			_student.Courses.Add(course);

			// 2024
			course = new Course() { Year = 2024 };
			course.Assessments.Add(new Assessment() { Grade = 66.666, Weight = 50 });
			course.Assessments.Add(new Assessment() { Grade = 33.333, Weight = 50 });
			_student.Courses.Add(course);
			course = new Course() { Year = 2024 };
			course.Assessments.Add(new Assessment() { Grade = 66.666, Weight = 75 });
			course.Assessments.Add(new Assessment() { Grade = 33.333, Weight = 25 });
			_student.Courses.Add(course);

			average = _student.GetAverage(2023);
			Assert.That(average, Is.EqualTo(81.3));

		}

		[Test]
		public void GetAverageForAllYears()
		{

			double average;
			Course course;

			// 2023
			course = new Course() { Year = 2023 };
			course.Assessments.Add(new Assessment() { Grade = 100, Weight = 50 });
			course.Assessments.Add(new Assessment() { Grade = 50, Weight = 50 });
			_student.Courses.Add(course);
			course = new Course() { Year = 2023 };
			course.Assessments.Add(new Assessment() { Grade = 100, Weight = 75 });
			course.Assessments.Add(new Assessment() { Grade = 50, Weight = 25 });
			_student.Courses.Add(course);

			// 2024
			course = new Course() { Year = 2024 };
			course.Assessments.Add(new Assessment() { Grade = 66.666, Weight = 50 });
			course.Assessments.Add(new Assessment() { Grade = 33.333, Weight = 50 });
			_student.Courses.Add(course);
			course = new Course() { Year = 2024 };
			course.Assessments.Add(new Assessment() { Grade = 66.666, Weight = 75 });
			course.Assessments.Add(new Assessment() { Grade = 33.333, Weight = 25 });
			_student.Courses.Add(course);

			average = _student.GetAverage();
			Assert.That(average, Is.EqualTo(67.7));

		}

	}

}
