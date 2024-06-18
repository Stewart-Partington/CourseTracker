using CourseTracker.Application.Interfaces;
using CourseTracker.Application.SchoolYears.Commands.Factory;
using CourseTracker.Application.Students.Commands.Factory;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Domain.SchoolYears;
using CourseTracker.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.SchoolYears.Commands.UpdateSchoolYear
{
    
    public class UpdateSchoolYearCommand : IUpdateSchoolYearCommand
    {

        private readonly IDatabaseService _database;
        private readonly ISchoolYearFactory _factory;

        public UpdateSchoolYearCommand(IDatabaseService database, ISchoolYearFactory factory)
        {
            _database = database;
            _factory = factory;
        }

        public async Task ExecuteAsync(UpdateSchoolYearModel model)
        {

            SchoolYear schoolYear = _factory.Create(model);

            _database.SchoolYears.Update(schoolYear);
            await _database.SaveAsync();

        }

    }

}
