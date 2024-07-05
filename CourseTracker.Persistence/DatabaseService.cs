using Castle.Core.Logging;
using CourseTracker.Application.Interfaces;
using CourseTracker.Domain;
using CourseTracker.Domain.Assessments;
using CourseTracker.Domain.Attachments;
using CourseTracker.Domain.Courses;
using CourseTracker.Domain.SchoolYears;
using CourseTracker.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Persistence
{
	
	public class DatabaseService : DbContext, IDatabaseService
	{

		private string _connectionString;
        private readonly ILogger<DatabaseService> _logger;

        //     public DatabaseService(string connectionString)
        //     {
        //_connectionString = connectionString;
        //     }

        public DatabaseService(ILogger<DatabaseService> logger)
        {
            
			IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<DatabaseService>()
            .Build();

            _logger = logger;

			_connectionString = GetConnectionString();

        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

		public DbSet<Student> Students { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Course> Courses { get; set; }
		public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public async Task<Guid> InsertAsync<t>(EntityBase entity)
        {

			Guid result;

			switch (typeof(t).Name)
			{
				
				case nameof(Student):
					Students.Add((Student)entity);
						break;

				case nameof(SchoolYear):
					SchoolYears.Add((SchoolYear)entity);
					break;

				case nameof(Course):
					Courses.Add((Course)entity);
					break;

				case nameof(Assessment):
					Assessments.Add((Assessment)entity);
					break;

				case nameof(Attachment):
					Attachments.Add((Attachment)entity);
					break;

			}

			await this.SaveChangesAsync();

			result = (Guid)entity.Id;

			return result;

		}

		public async Task SaveAsync()
		{
			await this.SaveChangesAsync();
		}

		private string GetConnectionString()
		{

			string result = null;

			if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower() == "development")
			{

                IConfigurationRoot config = new ConfigurationBuilder()
				.AddUserSecrets<DatabaseService>()
				.Build();

                result = config["sqlconnectionstring"];

            }
			else
			{
				result = Environment.GetEnvironmentVariable("sqlconnectionstring");
            }

            _logger.LogInformation($"CourseTracker.Persistence.DatabaseService _connectionString = {_connectionString}");

            return result;

		}

	}

}
