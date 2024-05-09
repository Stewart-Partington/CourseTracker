using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Assessments
{

	[TestFixture]
	public class AssessmentTests
	{

		private Assessment _assessment;
		private Guid _id;

		[SetUp]
		public void SetUp()
		{
			_assessment = new Assessment();
			_id = Guid.NewGuid();
		}
		
		[Test]
		public void TesSetAndGetId()
		{
			_assessment.Id = _id;

			Assert.That(_assessment.Id, Is.EqualTo(_id));
		}

	}

}
