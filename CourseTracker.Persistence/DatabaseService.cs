using CourseTracker.Application.Interfaces;
using CourseTracker.Domain;
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

        public DatabaseService(string connectionString)
        {
			_connectionString = connectionString;
        }

        public DatabaseService()
        {
			IConfiguration config = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();

			_connectionString = config.GetConnectionString("SQLConnectionString");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Assessment> Assessments { get; set; }

		public Guid Insert<t>(EntityBase entity)
		{

			Guid result;

			switch (typeof(t).Name)
			{
				case nameof(Student):
				Students.Add((Student)entity);
				break;
			}

			try
			{
				this.SaveChanges();
			}
			catch (Exception ex)
			{
				string message = ex.Message;
			}
			result = (Guid)entity.Id;

			return result;

		}

		public void Save()
		{
			this.SaveChanges();
		}

	}

}
