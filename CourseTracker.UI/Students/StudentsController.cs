﻿using AutoMapper;
using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.Application.Students.Queries.GetStudentsList;
using CourseTracker.Domain.Students;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Services.State;
using CourseTracker.UI.Students.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CourseTracker.UI.Students
{
	
	public class StudentsController : Controller
	{

		private readonly IApiDal _dal;
		private readonly IMapper _mapper;
		private readonly IState _state;

        public StudentsController(IApiDal dal, IMapper mapper, IState state)
        {
			_dal = dal;
			_mapper = mapper;
			_state = state;
        }

		[HttpGet]
        public async Task<IActionResult> Index()
		{

			List<StudentListItemModel> students = await _dal.GetStudents();

			ViewBag.Students = students;
			
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
				else
				{
					var updateStudent = _mapper.Map<UpdateStudentModel>(vmStudent);
					await _dal.UpdateStudent(updateStudent);
				}

				return RedirectToAction("Index");
            }
            else
			{
                ViewBag.SchoolYears = await _dal.GetSchoolYears((Guid)vmStudent.Id);
                return View(vmStudent);
			}

		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid sid)
		{

			await _dal.DeleteStudent(sid);

            return RedirectToAction("Index");

        }

	}

}
