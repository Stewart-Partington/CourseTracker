using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.Application.Courses.Queries.GetCoursesList;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList;
using CourseTracker.Application.Students.Queries.GetStudentsList;
using CourseTracker.Domain;

namespace CourseTracker.UI.Services.DAL
{
	
	public interface IApiDal
	{

		// Get Lists
		Task<List<StudentListItemModel>> GetStudents();
		Task<List<SchoolYearsListItemModel>> GetSchoolYears(Guid studentId);
		Task<List<CoursesListItemModel>> GetCourses(Guid schoolYearId);
		Task<List<AssessmentsListItemModel>> GetAssessments(Guid courseId);

        // Use of Generics
        Task<Guid> AddEntity<t>(EntityBase entity);
        //Task UpdateEntity(EntityBase entity);
        //Task<EntityBase> GetEntity<t>(Guid id, bool getChildObjects = false);
        //Task DeleteEntity<t>(Guid id);


    }

}
