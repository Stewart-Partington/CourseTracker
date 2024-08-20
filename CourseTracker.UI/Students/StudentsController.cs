using AutoMapper;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.Application.Students.Queries.GetStudentsList;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Services.State;
using CourseTracker.UI.Shared.Controllers;
using CourseTracker.UI.Students.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using static CourseTracker.UI.Models.Enums;

namespace CourseTracker.UI.Students
{

    public class StudentsController : BaseController
	{

        public StudentsController(IApiDal dal, IMapper mapper, IState state)
			: base (dal, mapper, state)
        {

        }

		[HttpGet]
        public async Task<IActionResult> Index()
		{

			List<StudentListItemModel> students = await _dal.GetStudents();

			ViewBag.Students = students;
			HandleEntityIds(EntityTypes.Students, null);
			
			return View();

		}

		[HttpGet]
		public async Task<IActionResult> Detail(Guid? sid)
		{

			VmStudent result = null;

			if (sid == null)
				result = new VmStudent();
			else
			{
				StudentDetailModel studentDetail = await _dal.GetStudent((Guid)sid);
				result = _mapper.Map<VmStudent>(studentDetail);
                ViewBag.SchoolYears = await _dal.GetSchoolYears((Guid)sid);
            }

            HandleEntityIds(EntityTypes.Student, result);

            return View(result);

		}

		[HttpPost]
		public async Task<IActionResult> Detail(VmStudent vmStudent)
		{

			if (ModelState.IsValid)
			{

				Guid sid;

				if (vmStudent.Id == null)
				{
                    var createStudent = _mapper.Map<CreateStudentModel>(vmStudent);
                    sid = await _dal.CreateStudent(createStudent);
				}
				else
				{
					var updateStudent = _mapper.Map<UpdateStudentModel>(vmStudent);
					await _dal.UpdateStudent(updateStudent);
					sid = updateStudent.Id;
				}

				return RedirectToAction("Detail", "Students", new { sid = sid } );
            }
            else
			{
                ViewBag.SchoolYears = await _dal.GetSchoolYears((Guid)vmStudent.Id);
                HandleEntityIds(EntityTypes.Student, null);
                return View(vmStudent);
			}

		}

		[HttpGet]
		public async Task<IActionResult> Delete()
		{

			await _dal.DeleteStudent(StudentId);

            return RedirectToAction("Index");

        }

	}

}
