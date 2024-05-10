using CourseTracker.Application.Students.Commands.CreateStudent;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Commands.Factory
{

	[TestFixture]
	public class StudentFactoryTests
	{

		private StudentFactory _factory;

		[SetUp]
		public void SetUp() {
			_factory = new StudentFactory();		
		}

		[Test]
		public void CreateStudentFromCreateStudentModel()
		{

			CreateStudentModel createStudentModel = new CreateStudentModel()
			{
				FirstName = "First_Name",
				LastName = "Last_Name",
				ProgramName = "Program_Name"
			};
			var result = _factory.Create(createStudentModel);

			Assert.That(result.FirstName, Is.EqualTo(createStudentModel.FirstName));
			Assert.That(result.LastName, Is.EqualTo(createStudentModel.LastName));
			Assert.That(result.ProgramName, Is.EqualTo(createStudentModel.ProgramName));

		 }

	}

}
