using CourseTracker.Domain;
using System.Text.RegularExpressions;
using System;
using CourseTracker.Domain.Students;
using CourseTracker.Domain.Courses;
using CourseTracker.Domain.Assessments;
using System.Net.Http.Headers;
using System.Net;

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

		public async Task<List<Student>> GetStudents()
		{

			List<Student> result = null;
			var response = await _client.GetAsync("api/Students");

			if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<List<Student>>();

			return result;

		}

		public async Task<List<Course>> GetCourses(Guid studentId)
		{

			List<Course> result = null;
			var response = await _client.GetAsync($"api/Courses/{studentId}");

			if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<List<Course>>();

			return result;

		}

		public async Task<List<Assessment>> GetAssessments(Guid courseId)
		{

			List<Assessment> result = null;
			var response = await _client.GetAsync($"api/Assessments/{courseId}");

			if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<List<Assessment>>();

			return result;

		}

		#endregion

	}

}
