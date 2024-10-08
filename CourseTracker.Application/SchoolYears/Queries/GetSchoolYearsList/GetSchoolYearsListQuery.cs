﻿using CourseTracker.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList
{
    
    public class GetSchoolYearsListQuery : IGetSchoolYearsListQuery
    {

        private readonly IDatabaseService _database;

        public GetSchoolYearsListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<SchoolYearsListItemModel> Execute(Guid studentId)
        {

            var result = _database.SchoolYears
                .Where(x => x.StudentId == studentId)
                .Include(x => x.Courses)
                .ThenInclude(x => x.Assessments)
                .Select(x => new SchoolYearsListItemModel()
                {
                    Id = x.Id,
                    StudentId = x.StudentId,
                    Index = x.Index,
                    Year = x.Year,
                    Average = x.Average
                });

            return result.ToList();

        }

    }

}
