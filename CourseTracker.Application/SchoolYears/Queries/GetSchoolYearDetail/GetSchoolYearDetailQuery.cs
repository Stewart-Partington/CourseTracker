using CourseTracker.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.SchoolYears.Queries.GetSchoolYearDetail
{
    
    public class GetSchoolYearDetailQuery : IGetSchoolYearDetailQuery
    {

        private readonly IDatabaseService _database;

        public GetSchoolYearDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public SchoolYearDetailModel Execute(Guid schoolYearId)
        {

            var result = _database.SchoolYears
                .Where(x => x.Id == schoolYearId)
                .Include(x => x.Courses)
                .ThenInclude(x => x.Assessments)
                .Select(x => new SchoolYearDetailModel()
                {
                    Id = x.Id,
                    StudentId = x.StudentId,
                    Index = x.Index,
                    Year = x.Year,
                    Average = x.Average
                })
                .Single();

            return result;

        }

    }

}
