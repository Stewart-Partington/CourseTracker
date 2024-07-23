using AutoMapper;
using CourseTracker.React.Server.Students.Models;
using CourseTracker.React.Server.SchoolYears.Models;
using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.UpdateSchoolYear;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearDetail;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList;
using CourseTracker.Domain.SchoolYears;

namespace CourseTracker.React.Server.Services.AutoMapper
{
    
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {

            // Student
            CreateMap<VmStudent, StudentDetailModel>();
            CreateMap<VmStudent, CreateStudentModel>();
            CreateMap<VmStudent, UpdateStudentModel>();
            CreateMap<StudentDetailModel, VmStudent>();

            // SchoolYear
            CreateMap<VmSchoolYear, SchoolYearDetailModel>();
            CreateMap<VmSchoolYear, CreateSchoolYearModel>();
            CreateMap<VmSchoolYear, UpdateSchoolYearModel>();
            CreateMap<VmSchoolYear, SchoolYear>();
            CreateMap<SchoolYearDetailModel, VmSchoolYear>();
            CreateMap<SchoolYearsListItemModel, SchoolYear>();

        }

    }

}
