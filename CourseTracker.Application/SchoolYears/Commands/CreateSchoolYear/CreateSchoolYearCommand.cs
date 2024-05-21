using CourseTracker.Application.Interfaces;
using CourseTracker.Application.SchoolYears.Commands.Factory;
using CourseTracker.Domain.SchoolYears;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear
{

    public class CreateSchoolYearCommand : ICreateSchoolYearCommand
    {
        private readonly IDatabaseService _database;
        private readonly ISchoolYearFactory _factory;

        public CreateSchoolYearCommand(IDatabaseService database, ISchoolYearFactory factory)
        {
            _database = database;
            _factory = factory;
        }

        public async Task<Guid> Execute(CreateSchoolYearModel model)
        {

            Guid result = Guid.Empty;
            SchoolYear schoolYear = _factory.Create(model);

            result = await _database.InsertAsync<SchoolYear>(schoolYear);

            return result;

        }

    }

}
