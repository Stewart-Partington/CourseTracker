using CourseTracker.Domain;
using CourseTracker.Domain.Assessments;
using CourseTracker.Domain.Courses;
using CourseTracker.Domain.Students;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Interfaces
{
	
	public interface IDatabaseService
	{

		DbSet<Student> Students { get; set; }
		DbSet<Course> Courses { get; set; }
		DbSet<Assessment> Assessments { get; set; }

		Guid Insert<t>(EntityBase entity);

	}

}
