using AutoMapper;
using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.UI.Students.Models;

namespace CourseTracker.UI.Services.AutoMapper
{
    
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {

            // Student
            CreateMap<VmStudent, StudentDetailModel>();

        }

    }

}
