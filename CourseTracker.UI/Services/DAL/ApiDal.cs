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
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CourseTracker.Domain.SchoolYears;
using Newtonsoft.Json;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearDetail;
using CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.UpdateSchoolYear;

namespace CourseTracker.UI.Services.DAL
{
	
	public class ApiDal : IApiDal
	{

		#region Declarations

		private readonly HttpClient _client;

		private const string _studentsController = "api/Students";
		private const string _schoolsYearController = "api/SchoolYears";
		private const string _coursesController = "api/Courses";
		private const string _assementsController = "api/Assessments";

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

		#region Students

		public async Task<List<StudentListItemModel>> GetStudents()
		{

			List<StudentListItemModel> result = null;
			var response = await _client.GetAsync(_studentsController);

			if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<List<StudentListItemModel>>();

			return result;

		}

		public async Task<StudentDetailModel> GetStudent(Guid Id)
		{

			StudentDetailModel result = null;
			var response = await _client.GetAsync($"{_studentsController}/{Id}");

			if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<StudentDetailModel>();

			return result;

		}

        public async Task<Guid> CreateStudent(CreateStudentModel createStudent)
		{

            Guid result = Guid.Empty;
            var response = await _client.PostAsJsonAsync(_studentsController, createStudent);

			if (response.StatusCode == HttpStatusCode.Created)
                result = await response.Content.ReadFromJsonAsync<Guid>();

			return result;

        }

		public async Task UpdateStudent(UpdateStudentModel updateStudent)
		{

            var response = await _client.PutAsJsonAsync(_studentsController, updateStudent);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }

		public async Task DeleteStudent(Guid id)
		{

            var response = await _client.DeleteAsync($"{_studentsController}/{id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }

        #endregion

        #region SchoolYear

        public async Task<List<SchoolYearsListItemModel>> GetSchoolYears(Guid studentId)
        {

            List<SchoolYearsListItemModel> result = null;
            var response = await _client.GetAsync($"{_studentsController}/{studentId}/SchoolYears");

            if (response.StatusCode == HttpStatusCode.OK)
                result = await response.Content.ReadFromJsonAsync<List<SchoolYearsListItemModel>>();

            return result;

        }

		public async Task<SchoolYearDetailModel> GetSchoolYear(Guid id)
		{

            SchoolYearDetailModel result = null;
            var response = await _client.GetAsync($"{_schoolsYearController}/{id}");

            if (response.StatusCode == HttpStatusCode.OK)
                result = await response.Content.ReadFromJsonAsync<SchoolYearDetailModel>();

            return result;

        }

		public async Task<Guid> CreateSchoolYear(CreateSchoolYearModel createSchoolYear)
		{

            Guid result = Guid.Empty;
            var response = await _client.PostAsJsonAsync(_schoolsYearController, createSchoolYear);

            if (response.StatusCode == HttpStatusCode.Created)
                result = await response.Content.ReadFromJsonAsync<Guid>();

            return result;

        }

		public async Task UpdateSchoolYear(UpdateSchoolYearModel updateSchoolYear)
        {

            var response = await _client.PutAsJsonAsync(_schoolsYearController, updateSchoolYear);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }

		public async Task DeleteSchoolYear(Guid id)
		{

            var response = await _client.DeleteAsync($"{_schoolsYearController}/{id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }

        #endregion

        #region Old

        public async Task<List<CoursesListItemModel>> GetCourses(Guid schoolYearId)
		{

			List<CoursesListItemModel> result = null;
			var response = await _client.GetAsync($"{_coursesController}/{schoolYearId}");

			if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<List<CoursesListItemModel>>();

			return result;

		}

		public async Task<List<AssessmentsListItemModel>> GetAssessments(Guid courseId)
		{

			List<AssessmentsListItemModel> result = null;
			var response = await _client.GetAsync($"{_assementsController}/{courseId}");

			if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<List<AssessmentsListItemModel>>();

			return result;

		}

		#endregion

		#region Generics

		public async Task<Guid> AddEntity<t>(EntityBase entity)
		{

            Guid result = Guid.Empty;
			string controllerName = GetControllerName<t>();
			var response = await _client.PostAsJsonAsync(controllerName, entity);

			if (response.StatusCode == HttpStatusCode.Created)
				result = JsonConvert.DeserializeObject<Guid>(response.Content.ToString());

            return result;

        }

		public async Task UpdateEntity<t>(EntityBase entity)
		{

            string controllerName = GetControllerName<t>();
            var response = await _client.PutAsJsonAsync(controllerName, entity);

			if (response.StatusCode != HttpStatusCode.OK)
				throw new Exception(response.RequestMessage.ToString());

        }

		public async Task<EntityBase> GetEntity<t>(Guid id, bool getChildObjects = false)
		{

			EntityBase result = null;
            string controllerName = GetControllerName<t>();
            var response = await _client.GetAsync($"{controllerName}/{id}");

            if (response.StatusCode != HttpStatusCode.OK)
                result = await response.Content.ReadFromJsonAsync<EntityBase>();

            return result;

		}

        public async Task DeleteEntity<t>(Guid id)
		{

            string controllerName = GetControllerName<t>();
            var response = await _client.DeleteAsync($"{controllerName}/{id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }


        private string GetControllerName<t>()
		{

			string result = null;

            switch (typeof(t).Name)
            {
                case nameof(Student):
                    result = _studentsController;
                    break;

                case nameof(SchoolYear):
					result = _schoolsYearController;
					break;

				case nameof(Course):
					result = _coursesController;
					break;

				case nameof(Assessment):
					result = _assementsController;
					break;
            }

            return result;

		}

        #endregion

    }

}
