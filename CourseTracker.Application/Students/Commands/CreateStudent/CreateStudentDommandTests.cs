using CourseTracker.Application.Interfaces;
using CourseTracker.Application.Students.Commands.Factory;
using CourseTracker.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Commands.CreateStudent
{

	[TestFixture]
	public class CreateStudentDommandTests
	{

		private CreateStudentCommand _command;
		private AutoMocker _mocker;
		private CreateStudentModel _model;
		private Student _student;

		[SetUp] 
		public void SetUp() {
		
			_model  = new CreateStudentModel()
			{
				FirstName = "First_Name",
				LastName = "Last_Name",
				ProgramName = "Program_Name"
			};
			_student = new Student();
			_mocker = new AutoMocker();

			//_mocker.GetMock<IDatabaseService>()
			//	.Setup(x => x.Students)
			//	.Returns(_mocker.GetMock<DbSet<Student>>().Object);

			_mocker.GetMock<IDatabaseService>()
				.Setup(x => x.Students)
				.Returns(_mocker.GetMock<DbSet<Student>>().Object);

			_mocker.GetMock<IStudentFactory>()
				.Setup(x => x.Create(_model))
				.Returns(_student);

			_command = _mocker.CreateInstance<CreateStudentCommand>();

		}

		[Test]
		public async Task TestExecuteShouldAddStudentToTheDatabase()
		{
			await _command.ExecuteAsync(_model);

			_mocker.GetMock<DbSet<Student>>()
				.Verify(p => p.Add(_student), Times.Never);
		}

	}

}
