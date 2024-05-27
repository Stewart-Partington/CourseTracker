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
                CourseDetailModel courseDetailModel = await _dal.GetCourse((Guid)entityIds.Student.Value.Key, 
                    (Guid)entityIds.SchoolYear.Value.Key, (Guid)cid);
                result = _mapper.Map<VmCourse>(courseDetailModel);
                ViewBag.Assessments = await _dal.GetAssessments((Guid)entityIds.Student.Value.Key, (Guid)entityIds.SchoolYear.Value.Key, (Guid)cid);
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
                EntityIds entityIds = _state.EntityIds;

                if (vmCourse.Id == null)
                {
                    var createCourse = _mapper.Map<CreateCourseModel>(vmCourse);
                    createCourse.StudentId = (Guid)entityIds.Student.Value.Key;
                    createCourse.SchoolYearId = (Guid)entityIds.SchoolYear.Value.Key;
                    cid = await _dal.CreateCourse(createCourse);
                }
                else
                {
                    var updateCourse = _mapper.Map<UpdateCourseModel>(vmCourse);
                    updateCourse.SchoolYearId = (Guid)entityIds.SchoolYear.Value.Key;
                    await _dal.UpdateCourse(updateCourse);
                    cid = updateCourse.Id;
                }

                return RedirectToAction("Detail", "Courses", new { cid = cid });

            }
            else
            {
                EntityIds entityIds = _state.EntityIds;
                ViewBag.Assessments = await _dal.GetAssessments((Guid)entityIds.Student.Value.Key, (Guid)entityIds.SchoolYear.Value.Key, (Guid)vmCourse.Id);
                HandleEntityIds(EntityTypes.Course, vmCourse);
                return View(vmCourse);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {

            await _dal.DeleteCourse((Guid)_state.EntityIds.Course.Value.Key);

            return RedirectToAction("Detail", "SchoolYears", new { syid = _state.EntityIds.SchoolYear.Value.Key });

        }

    }
}
