using CourseTracker.Domain.Assessments;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Courses
{
	
	[TestFixture]
	public class CourseTests
	{

		private Course _course;
		private Guid _id;

		[SetUp]
		public void SetUp()
		{
			_course = new Course();
			_id = Guid.NewGuid();
		}

		[Test]
		public void SetAndGetId()
		{
			_course.Id = _id;

			Assert.That(_course.Id, Is.EqualTo(_id));
		}

		[Test]
		public void Assert0PercentGrade()
		{

			Assert.That(_course.Grade, Is.EqualTo(0));

		}

		[Test]
		public void Assert1AssesmentWith0Percent()
		{

            _course.Assessments.Add(new Assessment() { Grade = 0, Weight = 50 });

            Assert.That(_course.Grade, Is.EqualTo(0));

        }

		[Test]
		public void Assert50PercentGrade()
		{

			_course.Assessments.Add(new Assessment() { Grade = 100, Weight = 50 });
			_course.Assessments.Add(new Assessment() { Grade = 0, Weight = 50 });

			Assert.That(_course.Grade, Is.EqualTo(50.0));

		}

		[Test]
		public void Assert66PercentGrade()
		{

			_course.Assessments.Add(new Assessment() { Grade = 100, Weight = 33.3 });
			_course.Assessments.Add(new Assessment() { Grade = 100, Weight = 33.3 });
			_course.Assessments.Add(new Assessment() { Grade = 0, Weight = 33.3 });

			Assert.That(_course.Grade, Is.EqualTo(66.7));

		}

		[Test]
		public void Assert100PercentGrade()
		{

			_course.Assessments.Add(new Assessment() { Grade = 100, Weight = 33.333 });
			_course.Assessments.Add(new Assessment() { Grade = 100, Weight = 33.333 });
			_course.Assessments.Add(new Assessment() { Grade = 100, Weight = 33.333 });

			Assert.That(_course.Grade, Is.EqualTo(100.0));

		}

		[Test]
		public void Assert100PercentCeiling()
		{

            _course.Assessments.Add(new Assessment() { Grade = 100, Weight = 33.333 });

			Assert.That(_course.Grade, Is.EqualTo(100.0));

        }

	}
}
