using AutoMapper;
using CourseTracker.Application.Courses.Commands.CreateCourse;
using CourseTracker.Application.Courses.Commands.UpdateCourse;
using CourseTracker.Application.Courses.Queries.GetCourseDetail;
using CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.UpdateSchoolYear;
using CourseTracker.UI.Courses.Models;
using CourseTracker.UI.Models;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Services.State;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using static CourseTracker.UI.Models.Enums;

namespace CourseTracker.UI.Courses
{
    public class CoursesController : ControllerBase
    {

        public CoursesController(IApiDal dal, IMapper mapper, IState state)
            : base(dal, mapper, state)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? cid)
        {

            VmCourse result = null;

            if (cid == null)
                result = new VmCourse();
            else
            {
                EntityIds entityIds = _state.EntityIds;
                CourseDetailModel courseDetailModel = await _dal.GetCourse(StudentId, SchoolYearId, (Guid)cid);
                result = _mapper.Map<VmCourse>(courseDetailModel);
                ViewBag.Assessments = await _dal.GetAssessments(StudentId, SchoolYearId, (Guid)cid);
            }

            HandleEntityIds(EntityTypes.Course, result);

            return View(result);

        }

        [HttpPost]
        public async Task<IActionResult> Detail(VmCourse vmCourse)
        {

            if (ModelState.IsValid)
            {

                Guid cid;

                if (vmCourse.Id == null)
                {
                    var createCourse = _mapper.Map<CreateCourseModel>(vmCourse);
                    createCourse.StudentId = StudentId;
                    createCourse.SchoolYearId = SchoolYearId;
                    cid = await _dal.CreateCourse(createCourse);
                }
                else
                {
                    var updateCourse = _mapper.Map<UpdateCourseModel>(vmCourse);
                    updateCourse.SchoolYearId = SchoolYearId;
                    await _dal.UpdateCourse(updateCourse);
                    cid = updateCourse.Id;
                }

                return RedirectToAction("Detail", "Courses", new { cid = cid });

            }
            else
            {
                ViewBag.Assessments = await _dal.GetAssessments(StudentId, SchoolYearId, (Guid)vmCourse.Id);
                HandleEntityIds(EntityTypes.Course, vmCourse);
                return View(vmCourse);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {

            await _dal.DeleteCourse(CourseId);

            return RedirectToAction("Detail", "SchoolYears", new { syid = SchoolYearId });

        }

    }
}
