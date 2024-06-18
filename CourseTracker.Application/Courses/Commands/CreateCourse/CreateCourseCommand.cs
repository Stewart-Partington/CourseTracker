using CourseTracker.Application.Courses.Commands.Factory;
using CourseTracker.Application.Interfaces;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Commands.CreateCourse
{

    public class CreateCourseCommand : ICreateCourseCommand
    {

        private readonly IDatabaseService _database;
        private readonly ICourseFactory _factory;

        public CreateCourseCommand(IDatabaseService database, ICourseFactory factory)
        {
            _database = database;
            _factory = factory;
        }

        public async Task<Guid> ExecuteAsync(CreateCourseModel model)
        {

            Guid result = Guid.Empty;
            Course course = _factory.Create(model);

            result = await _database.InsertAsync<Course>(course);

            return result;

        }

    }

}
