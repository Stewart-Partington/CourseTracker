using CourseTracker.Application.Interfaces;
using CourseTracker.Domain.Assessments;
using CourseTracker.Domain.Courses;
using CourseTracker.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Persistence
{
	
	public class DatabaseService : DbContext, IDatabaseService
	{

		private string _connectionString;

		//      public DatabaseService(IConfiguration configuration)
		//      {
		//	_connectionString = configuration.GetConnectionString("SQLConnectionString");
		//}

		public DatabaseService()
        {
			IConfiguration config = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();

			_connectionString = config.GetConnectionString("SQLConnectionString");
		}

        public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Assessment> Assessments { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

	}

}
