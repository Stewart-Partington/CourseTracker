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

		public async Task<IActionResult> Details(Guid id)
		{

			return null;

		}

	}

}
