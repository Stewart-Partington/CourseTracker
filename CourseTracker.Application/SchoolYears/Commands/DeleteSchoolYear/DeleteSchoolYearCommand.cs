using CourseTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.SchoolYears.Commands.DeleteSchoolYear
{
    
    public class DeleteSchoolYearCommand : IDeleteSchoolYearCommand
    {

        private readonly IDatabaseService _database;

        public DeleteSchoolYearCommand(IDatabaseService database)
        {
            _database = database;
        }

        public async Task ExecuteAsync(Guid schoolYearId)
        {

            var student = _database.SchoolYears.Find(schoolYearId);

            _database.SchoolYears.Remove(student);
            await _database.SaveAsync();

        }

    }

}
