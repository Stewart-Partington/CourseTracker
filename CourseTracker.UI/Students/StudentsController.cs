using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.Application.Students.Queries.GetStudentsList;
using CourseTracker.UI.Services.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CourseTracker.UI.Students
{
	
	public class StudentsController : Controller
	{

		private readonly IApiDal _dal;

        public StudentsController(IApiDal dal)
        {
			_dal = dal;
        }

        public async Task<IActionResult> Index()
		{

			List<StudentListItemModel> students = await _dal.GetStudents();

			ViewBag.Students = students;
			
			return View();

		}

		public async Task<IActionResult> Detail(Guid? id)
		{

			// ToDo:
			// 1. Create VmStudent
			// 2. If id
			//		1. Get From DAL (Write method)
			//		2. Create AutoMapper for Student and VmStudent
			//		3. Create Question Editor Template
			//		4. Post, update and redirect
			// 3. Else
			// et cetera...

			return null;

		}

	}

}
