using CourseTracker.Application.Assessments.Commands.CreateAssessment;
using CourseTracker.Application.Assessments.Commands.UpdateAssessment;
using CourseTracker.Application.Assessments.Queries.GetAssementDetail;
using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.Application.Courses.Commands.CreateCourse;
using CourseTracker.Application.Courses.Commands.UpdateCourse;
using CourseTracker.Application.Courses.Queries.GetCourseDetail;
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
		Task<SchoolYearDetailModel> GetSchoolYear(Guid studentId, Guid schoolYearId);
		Task<Guid> CreateSchoolYear(CreateSchoolYearModel createSchoolYear);
		Task UpdateSchoolYear(UpdateSchoolYearModel updateSchoolYear);
		Task DeleteSchoolYear(Guid id);

		// Courses
		Task<List<CoursesListItemModel>> GetCourses(Guid studentId, Guid schoolYearId);
		Task<CourseDetailModel> GetCourse(Guid studentId, Guid schoolYearId, Guid courseId);
		Task<Guid> CreateCourse(CreateCourseModel createCourse);
		Task UpdateCourse(UpdateCourseModel updateCourse);
		Task DeleteCourse(Guid id);

		// Assessments
		Task<List<AssessmentsListItemModel>> GetAssessments(Guid studentId, Guid schoolYearId, Guid courseId);
		Task<AssessmentDetailModel> GetAssessment(Guid studentId, Guid schoolYearId, Guid courseId, Guid assessmentId);
		Task<Guid> CreateAssessment(CreateAssessmentModel createAssessment);
		Task UpdateAssessment(UpdateAssessmentModel updateAssessment);
		Task DeleteAssessment(Guid id);

	}

}
