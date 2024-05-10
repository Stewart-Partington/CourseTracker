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

		private readonly IConfiguration _configuration;

		public DatabaseService(IConfiguration configuration)
        {
			_configuration = configuration;

			Database.EnsureCreated();
		}

        public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Assessment> Assessments { get; set; }

	}

}
