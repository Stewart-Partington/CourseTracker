using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.Application.Courses.Queries.GetCoursesList;
using CourseTracker.Application.Students.Queries.GetStudentsList;

namespace CourseTracker.UI.Services.DAL
{
	
	public interface IApiDal
	{

		// Get Lists
		Task<List<StudentListItemModel>> GetStudents();
		Task<List<CoursesListItemModel>> GetCourses(Guid studentId);
		Task<List<AssessmentsListItemModel>> GetAssessments(Guid courseId);

		//Task<Guid> AddEntity<t>(EntityBase entity);
		//Task UpdateEntity(EntityBase entity);
		//Task<EntityBase> GetEntity<t>(Guid id, bool getChildObjects = false);
		//Task DeleteEntity<t>(Guid id);
		//Task DeleteEntity(EntityBase entity);

	}

}
