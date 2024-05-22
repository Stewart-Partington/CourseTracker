using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.Application.Courses.Queries.GetCoursesList;
using CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.UpdateSchoolYear;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearDetail;
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
		Task<SchoolYearDetailModel> GetSchoolYear(Guid id);
		Task<Guid> CreateSchoolYear(CreateSchoolYearModel createSchoolYear);
		Task UpdateSchoolYear(UpdateSchoolYearModel updateSchoolYear);
		Task DeleteSchoolYear(Guid id);

		// Courses
		Task<List<CoursesListItemModel>> GetCourses(Guid schoolYearId);

		// Assessments
		Task<List<AssessmentsListItemModel>> GetAssessments(Guid courseId);

	}

}
