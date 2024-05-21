using AutoMapper;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.Domain.Students;
using CourseTracker.UI.Students.Models;

namespace CourseTracker.UI.Services.AutoMapper
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
