using CourseTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Queries.GetStudentDetail
{
	
	public class GetStudentDetailQuery : IGetStudentDetailQuery
	{

		private readonly IDatabaseService _database;

		public GetStudentDetailQuery(IDatabaseService database)
		{
			_database = database;
		}

		public StudentDetailModel Execute(Guid studentId)
		{

			var result = _database.Students
				.Where(x => x.Id == studentId)
				.Select(x => new StudentDetailModel()
				{
					Id = x.Id,
					FirstName = x.FirstName,
					LastName = x.LastName,
					ProgramName = x.ProgramName
				})
				.Single();

			return result;

		}

	}

}
