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
		public void TesSetAndGetId()
		{
			_course.Id = _id;

			Assert.That(_course.Id, Is.EqualTo(_id));
		}

	}
}
