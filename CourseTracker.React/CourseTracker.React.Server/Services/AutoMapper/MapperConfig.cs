using AutoMapper;
using CourseTracker.React.Server.Students.Models;
using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Commands.UpdateStudent;

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

        }

    }

}
