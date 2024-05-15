using CourseTracker.Domain;
using System.Text.RegularExpressions;
using System;
using CourseTracker.Domain.Students;
using CourseTracker.Domain.Courses;
using CourseTracker.Domain.Assessments;
using System.Net.Http.Headers;
using System.Net;
using CourseTracker.Application.Students.Queries.GetStudentsList;
using CourseTracker.Application.Courses.Queries.GetCoursesList;
using CourseTracker.Application.Assessments.Queries.GetAssessmentList;

namespace CourseTracker.UI.Services.DAL
{
	
	public class ApiDal : IApiDal
	{

		#region Declarations

		private readonly HttpClient _client;

		#endregion

		#region Constructors

		public ApiDal(HttpClient client, IConfiguration config)
        {

			_client = client;

			_client.BaseAddress = new Uri(config.GetValue<string>("ApiUrl"));

			_client.DefaultRequestHeaders.Accept.Clear();
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

		}

		#endregion

		#region Get Lists

		public async Task<List<StudentListItemModel>> GetStudents()
		{

			List<StudentListItemModel> result = null;
			var response = await _client.GetAsync("api/Students");

			if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<List<StudentListItemModel>>();

			return result;

		}

		public async Task<List<CoursesListItemModel>> GetCourses(Guid studentId)
		{

			List<CoursesListItemModel> result = null;
			var response = await _client.GetAsync($"api/Courses/{studentId}");

			if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<List<CoursesListItemModel>>();

			return result;

		}

		public async Task<List<AssessmentsListItemModel>> GetAssessments(Guid courseId)
		{

			List<AssessmentsListItemModel> result = null;
			var response = await _client.GetAsync($"api/Assessments/{courseId}");

			if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<List<AssessmentsListItemModel>>();

			return result;

		}

		#endregion

	}

}
