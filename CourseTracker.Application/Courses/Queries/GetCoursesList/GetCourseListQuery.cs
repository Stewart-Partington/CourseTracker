using CourseTracker.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Courses.Queries.GetCoursesList
{
    
    public class GetCourseListQuery : IGetCourseListQuery
    {

        private readonly IDatabaseService _database;

        public GetCourseListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<CoursesListItemModel> Execute(Guid schoolYearId)
        {

            var result = _database.Courses
                .Where(x => x.SchoolYearId == schoolYearId)
                .Include(x => x.Assessments)
                .Select(x => new CoursesListItemModel()
                {
                    Id = x.Id,
                    SchoolYearId = x.SchoolYearId,
                    Name = x.Name,
                    Semester = x.Semester,
                    Grade = x.Grade
                });

            return result.ToList();

        }

    }

}
