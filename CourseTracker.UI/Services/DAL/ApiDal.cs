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
using CourseTracker.Application.Courses.Commands.CreateCourse;
using CourseTracker.Application.Courses.Commands.UpdateCourse;
using CourseTracker.Application.Courses.Queries.GetCourseDetail;
using CourseTracker.Application.Assessments.Commands.CreateAssessment;
using CourseTracker.Application.Assessments.Commands.UpdateAssessment;
using CourseTracker.Application.Assessments.Queries.GetAssementDetail;
using CourseTracker.Application.Attachments.Commands.CreateAttachment;
using CourseTracker.Application.Attachments.Commands.UpdateAttachment;
using CourseTracker.Application.Attachments.Queries.GetAttachmentDetail;
using CourseTracker.Application.Attachments.Queries.GetAttachmentList;
using CourseTracker.Application.Interfaces;

namespace CourseTracker.UI.Services.DAL
{
	
	public class ApiDal : IApiDal
	{

		#region Declarations

		private readonly HttpClient _client;
        private readonly ILogger<ApiDal> _logger;

		private const string _api = "api/";
		private const string _studentsController = "Students";
		private const string _schoolsYearController = "SchoolYears";
		private const string _coursesController = "Courses";
		private const string _assementsController = "Assessments";
        private const string _attachmentsController = "Attachments";

        #endregion

        #region Constructors

        public ApiDal(HttpClient client, IConfiguration config, ILogger<ApiDal> logger)
        {

			_client = client;
            _logger = logger;

			_client.BaseAddress = GetApiUrl(config);

			_client.DefaultRequestHeaders.Accept.Clear();
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

		}

		#endregion

		#region Students

		public async Task<List<StudentListItemModel>> GetStudents()
		{

			List<StudentListItemModel> result = null;
			var response = await _client.GetAsync($"{_api}{_studentsController}");

			if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<List<StudentListItemModel>>();

			return result;

		}

		public async Task<StudentDetailModel> GetStudent(Guid Id)
		{

			StudentDetailModel result = null;
			var response = await _client.GetAsync($"{_api}{_studentsController}/{Id}");

			if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<StudentDetailModel>();

			return result;

		}

        public async Task<Guid> CreateStudent(CreateStudentModel createStudent)
		{

            Guid result = Guid.Empty;
            var response = await _client.PostAsJsonAsync($"{_api}{_studentsController}", createStudent);

			if (response.StatusCode == HttpStatusCode.Created)
                result = await response.Content.ReadFromJsonAsync<Guid>();

			return result;

        }

		public async Task UpdateStudent(UpdateStudentModel updateStudent)
		{

            var response = await _client.PutAsJsonAsync($"{_api}{_studentsController}", updateStudent);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }

		public async Task DeleteStudent(Guid id)
		{

            var response = await _client.DeleteAsync($"{_api}{_studentsController}/{id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }

        #endregion

        #region SchoolYears

        public async Task<List<SchoolYearsListItemModel>> GetSchoolYears(Guid studentId)
        {

            List<SchoolYearsListItemModel> result = null;
            var response = await _client.GetAsync($"{_api}{_studentsController}/{studentId}/SchoolYears");

            if (response.StatusCode == HttpStatusCode.OK)
                result = await response.Content.ReadFromJsonAsync<List<SchoolYearsListItemModel>>();

            return result;

        }

		public async Task<SchoolYearDetailModel> GetSchoolYear(Guid studentId, Guid schoolYearId)
        {

            SchoolYearDetailModel result = null;
            var response = await _client.GetAsync($"{_api}{_studentsController}/{studentId}/{_schoolsYearController}/{schoolYearId}");

            if (response.StatusCode == HttpStatusCode.OK)
                result = await response.Content.ReadFromJsonAsync<SchoolYearDetailModel>();

            return result;

        }

		public async Task<Guid> CreateSchoolYear(CreateSchoolYearModel createSchoolYear)
		{

            Guid result = Guid.Empty;
            var response = await _client.PostAsJsonAsync($"{_api}{_schoolsYearController}", createSchoolYear);
            object ex;

            if (response.StatusCode == HttpStatusCode.Created)
                result = await response.Content.ReadFromJsonAsync<Guid>();
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
                ex = await response.Content.ReadFromJsonAsync<object>();

            return result;

        }

		public async Task UpdateSchoolYear(UpdateSchoolYearModel updateSchoolYear)
        {

            var response = await _client.PutAsJsonAsync($"{_api}{_schoolsYearController}", updateSchoolYear);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }

		public async Task DeleteSchoolYear(Guid id)
		{

            var response = await _client.DeleteAsync($"{_api}{_schoolsYearController}/{id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }

        #endregion

        #region Courses

        public async Task<List<CoursesListItemModel>> GetCourses(Guid studentId, Guid schoolYearId)
        {

            List<CoursesListItemModel> result = null;
            var response = await _client.GetAsync($"{_api}{_studentsController}/{studentId}/{_schoolsYearController}/{schoolYearId}/{_coursesController}");

            if (response.StatusCode == HttpStatusCode.OK)
                result = await response.Content.ReadFromJsonAsync<List<CoursesListItemModel>>();

            return result;

        }

        public async Task<CourseDetailModel> GetCourse(Guid studentId, Guid schoolYearId, Guid courseId)
        {

            CourseDetailModel result = null;
            var response = await _client.GetAsync($"{_api}{_studentsController}/{studentId}/{_schoolsYearController}/{schoolYearId}/{_coursesController}/{courseId}");

            if (response.StatusCode == HttpStatusCode.OK)
                result = await response.Content.ReadFromJsonAsync<CourseDetailModel>();

            return result;

        }

        public async Task<Guid> CreateCourse(CreateCourseModel createCourse)
        {

            Guid result = Guid.Empty;
            var response = await _client.PostAsJsonAsync($"{_api}{_coursesController}", createCourse);
            object ex;

            if (response.StatusCode == HttpStatusCode.Created)
                result = await response.Content.ReadFromJsonAsync<Guid>();
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
                ex = await response.Content.ReadFromJsonAsync<object>();

            return result;

        }

        public async Task UpdateCourse(UpdateCourseModel updateCourse)
        {

            var response = await _client.PutAsJsonAsync($"{_api}{_coursesController}", updateCourse);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }

        public async Task DeleteCourse(Guid id)
        {

            var response = await _client.DeleteAsync($"{_api}{_coursesController}/{id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());
        }

        #endregion

        #region Assessments

        public async Task<List<AssessmentsListItemModel>> GetAssessments(Guid studentId, Guid schoolYearId, Guid courseId)
		{

			List<AssessmentsListItemModel> result = null;
            var response = await _client.GetAsync($"{_api}{_studentsController}/{studentId}/{_schoolsYearController}/{schoolYearId}/{_coursesController}/{courseId}/Assessments");

            if (response.StatusCode == HttpStatusCode.OK)
				result = await response.Content.ReadFromJsonAsync<List<AssessmentsListItemModel>>();

			return result;

		}

        public async Task<AssessmentDetailModel> GetAssessment(Guid studentId, Guid schoolYearId, Guid courseId, Guid assessmentId)
        {

            AssessmentDetailModel result = null;
            var response = await _client.GetAsync($"{_api}{_studentsController}/{studentId}/{_schoolsYearController}/{schoolYearId}/{_coursesController}/{courseId}/{_assementsController}/{assessmentId}");

            if (response.StatusCode == HttpStatusCode.OK)
                result = await response.Content.ReadFromJsonAsync<AssessmentDetailModel>();

            return result;

        }

        public async Task<Guid> CreateAssessment(CreateAssessmentModel createAssessment)
        {

            Guid result = Guid.Empty;
            var response = await _client.PostAsJsonAsync($"{_api}{_assementsController}", createAssessment);
            object ex;

            if (response.StatusCode == HttpStatusCode.Created)
                result = await response.Content.ReadFromJsonAsync<Guid>();
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
                ex = await response.Content.ReadFromJsonAsync<object>();

            return result;

        }

        public async Task UpdateAssessment(UpdateAssessmentModel updateAssessment)
        {

            var response = await _client.PutAsJsonAsync($"{_api}{_assementsController}", updateAssessment);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }

        public async Task DeleteAssessment(Guid id)
        {

            var response = await _client.DeleteAsync($"{_api}{_assementsController}/{id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }

        #endregion

        #region Attachments

        public async Task<List<AttachmentListItemModel>> GetAttachments(Guid studentId, Guid schoolYearId, Guid courseId, Guid assessmentId)
        {

            List<AttachmentListItemModel> result = null;
            var response = await _client.GetAsync($"{_api}{_studentsController}/{studentId}/{_schoolsYearController}/{schoolYearId}/{_coursesController}/{courseId}/{_assementsController}/{assessmentId}/{_attachmentsController}");

            if (response.StatusCode == HttpStatusCode.OK)
                result = await response.Content.ReadFromJsonAsync<List<AttachmentListItemModel>>();

            return result;

        }

        public async Task<AttachmentDetailModel> GetAttachment(Guid studentId, Guid schoolYearId, Guid courseId, Guid assessmentId, Guid attachmentid)
        {

            AttachmentDetailModel result = null;
            var response = await _client.GetAsync($"{_api}{_studentsController}/{studentId}/{_schoolsYearController}/{schoolYearId}/{_coursesController}/{courseId}/{_assementsController}/{assessmentId}/{_attachmentsController}/{attachmentid}");

            if (response.StatusCode == HttpStatusCode.OK)
                result = await response.Content.ReadFromJsonAsync<AttachmentDetailModel>();

            return result;

        }

        public async Task<Guid> CreateAttachment(CreateAttachmentModel createAttachment)
        {

            Guid result = Guid.Empty;
            var response = await _client.PostAsJsonAsync($"{_api}{_attachmentsController}", createAttachment);
            object ex;

            if (response.StatusCode == HttpStatusCode.Created)
                result = await response.Content.ReadFromJsonAsync<Guid>();
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
                ex = await response.Content.ReadFromJsonAsync<object>();

            return result;

        }

        public async Task UpdateAttachment(UpdateAttachmentModel updateAttachment)
        {

            var response = await _client.PutAsJsonAsync($"{_api}{_attachmentsController}", updateAttachment);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

        }

        public async Task DeleteAttachment(Guid id)
        {

            var response = await _client.DeleteAsync($"{_api}{_attachmentsController}/{id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.RequestMessage.ToString());

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

        #region Private Methods

        private Uri GetApiUrl(IConfiguration config)
        {

            Uri result = null;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower() == "development")
            {
                result = new Uri(config.GetValue<string>("ApiUrl"));
            }
            else
            {
                result = new Uri(Environment.GetEnvironmentVariable("apiurl"));
            }

            _logger.LogInformation($"CourseTracker.UI.ApiDal apiUrl = {result.ToString()}");

            return result;

        }

        #endregion

    }

}
