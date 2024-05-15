using CourseTracker.Domain;
using CourseTracker.Domain.Assessments;
using CourseTracker.Domain.Courses;
using CourseTracker.Domain.Students;

namespace CourseTracker.UI.Services.DAL
{
	
	public interface IApiDal
	{

		// Get Lists
		Task<List<Student>> GetStudents();
		Task<List<Course>> GetCourses(Guid studentId);
		Task<List<Assessment>> GetAssessments(Guid courseId);

		//Task<Guid> AddEntity<t>(EntityBase entity);
		//Task UpdateEntity(EntityBase entity);
		//Task<EntityBase> GetEntity<t>(Guid id, bool getChildObjects = false);
		//Task DeleteEntity<t>(Guid id);
		//Task DeleteEntity(EntityBase entity);

	}

}
