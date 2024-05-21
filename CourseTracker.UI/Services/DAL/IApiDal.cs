using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.Application.Courses.Queries.GetCoursesList;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.Application.Students.Queries.GetStudentsList;
using CourseTracker.Domain;

namespace CourseTracker.UI.Services.DAL
{
	
	public interface IApiDal
	{

		// Students
		Task<List<StudentListItemModel>> GetStudents();
		Task<StudentDetailModel> GetStudent(Guid Id);
		Task<Guid> CreateStudent(CreateStudentModel createStudent);
		Task UpdateStudent(UpdateStudentModel updateStudent);
		Task DeleteStudent(Guid id);

		// SchoolYears
		Task<List<SchoolYearsListItemModel>> GetSchoolYears(Guid studentId);

		// Courses
		Task<List<CoursesListItemModel>> GetCourses(Guid schoolYearId);

		// Assessments
		Task<List<AssessmentsListItemModel>> GetAssessments(Guid courseId);

	}

}
