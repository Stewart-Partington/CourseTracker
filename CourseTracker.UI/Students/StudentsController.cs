using AutoMapper;
using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Queries.GetStudentsList;
using CourseTracker.Domain.Students;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Students.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseTracker.UI.Students
{
	
	public class StudentsController : Controller
	{

		private readonly IApiDal _dal;
		private readonly IMapper _mapper;

        public StudentsController(IApiDal dal, IMapper mapper)
        {
			_dal = dal;
			_mapper = mapper;
        }

		[HttpGet]
        public async Task<IActionResult> Index()
		{

			List<StudentListItemModel> students = await _dal.GetStudents();

			ViewBag.Students = students;
			
			return View();

		}

		[HttpGet]
		public async Task<IActionResult> Detail(Guid? id)
		{

			// Write full dal with generics

			// ToDo:
			// 1. Create VmStudent
			// 2. If id
			//		1. Get From DAL (Write method - look at Interview)
			//		2. Create AutoMapper for Student and VmStudent
			//		3. Create Question Editor Template
			//		4. Post, update and redirect
			// 3. Else
			// et cetera...

			VmStudent result = null;

			if (id == null)
				result = new VmStudent();

			return View(result);

		}

		[HttpPost]
		public async Task<IActionResult> Detail(VmStudent vmStudent)
		{

			if (ModelState.IsValid)
			{

				if (vmStudent.Id == null)
				{
                    var createStudent = _mapper.Map<CreateStudentModel>(vmStudent);
                    await _dal.CreateStudent(createStudent);
				}
				//else
				//	_dal.UpdateEntity<Student>(createStudent);

				return RedirectToAction("Index");

			}
			else
			{
				return View(vmStudent);
			}

		}

	}

}
