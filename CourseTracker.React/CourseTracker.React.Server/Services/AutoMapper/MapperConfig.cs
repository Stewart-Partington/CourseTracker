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
using CourseTracker.React.Server.Courses.Models;
using CourseTracker.Application.Courses.Queries.GetCourseDetail;
using CourseTracker.Application.Courses.Queries.GetCoursesList;
using CourseTracker.Application.Courses.Commands.CreateCourse;
using CourseTracker.Application.Courses.Commands.UpdateCourse;
using CourseTracker.Domain.Courses;
using CourseTracker.Domain.Assessments;
using CourseTracker.React.Server.Assesments.Models;
using CourseTracker.Application.Assessments.Queries.GetAssementDetail;
using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.Application.Assessments.Commands.CreateAssessment;
using CourseTracker.Application.Assessments.Commands.UpdateAssessment;

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

            // Course
            CreateMap<VmCourse, CourseDetailModel>();
            CreateMap<VmCourse, CreateCourseModel>();
            CreateMap<VmCourse, UpdateCourseModel>();
            CreateMap<VmCourse, Course>();
            CreateMap<CourseDetailModel, VmCourse>();
            CreateMap<CoursesListItemModel, Course>();

            // Assessment
            CreateMap<VmAssessment, AssessmentDetailModel>();
            CreateMap<VmAssessment, CreateAssessmentModel>();
            CreateMap<VmAssessment, UpdateAssessmentModel>();
            CreateMap<VmAssessment, Assessment>();
            CreateMap<AssessmentDetailModel, VmAssessment>();
            CreateMap<AssessmentsListItemModel, Assessment>();

        }

    }

}
