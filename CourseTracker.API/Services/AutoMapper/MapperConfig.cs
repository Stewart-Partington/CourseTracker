using AutoMapper;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearDetail;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList;
using CourseTracker.Domain.SchoolYears;

namespace CourseTracker.API.Services.AutoMapper
{
    
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {

            // SchoolYear
            CreateMap<SchoolYearsListItemModel, SchoolYear>();

        }

    }

}
