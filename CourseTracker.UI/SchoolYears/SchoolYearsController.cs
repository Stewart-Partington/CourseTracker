using AutoMapper;
using CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.UpdateSchoolYear;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearDetail;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Domain.SchoolYears;
using CourseTracker.Domain.Students;
using CourseTracker.UI.SchoolYears.Models;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Services.State;
using CourseTracker.UI.Students.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using static CourseTracker.UI.Models.Enums;

namespace CourseTracker.UI.SchoolYears
{

    public class SchoolYearsController : ControllerBase
    {

        public SchoolYearsController(IApiDal dal, IMapper mapper, IState state)
            : base(dal, mapper, state)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? syid)
        {

            VmSchoolYear result = null;

            if (syid == null)
                result = new VmSchoolYear();
            else
            {
                SchoolYearDetailModel schoolYearDetail = await _dal.GetSchoolYear(StudentId, (Guid)syid);
                result = _mapper.Map<VmSchoolYear>(schoolYearDetail);
                ViewBag.Courses = await _dal.GetCourses(StudentId, (Guid)syid);
            }

            HandleEntityIds(EntityTypes.SchoolYear, result);

            return View(result);

        }

        [HttpPost]
        public async Task<IActionResult> Detail(VmSchoolYear vmSchoolYear)
        {

            if (ModelState.IsValid)
            {

                if (!await IsComplexValidationValid(vmSchoolYear))
                {
                    ViewBag.Courses = vmSchoolYear.Id == null ? null : await _dal.GetCourses(StudentId, (Guid)vmSchoolYear.Id);
                    HandleEntityIds(EntityTypes.SchoolYear, null);
                    return View(vmSchoolYear);
                }

                Guid syid;

                if (vmSchoolYear.Id == null)
                {
                    var createSchoolYear = _mapper.Map<CreateSchoolYearModel>(vmSchoolYear);
                    createSchoolYear.StudentId = StudentId;
                    syid = await _dal.CreateSchoolYear(createSchoolYear);
                }
                else
                {
                    var updaetSchoolYear = _mapper.Map<UpdateSchoolYearModel>(vmSchoolYear);
                    updaetSchoolYear.StudentId = StudentId;
                    await _dal.UpdateSchoolYear(updaetSchoolYear);
                    syid = updaetSchoolYear.Id;
                }

                return RedirectToAction("Detail", "SchoolYears", new { syid = syid });

            }
            else
            {
                ViewBag.Courses = vmSchoolYear.Id == null ? null : await _dal.GetCourses(StudentId, (Guid)vmSchoolYear.Id);
                HandleEntityIds(EntityTypes.SchoolYear, null);
                return View(vmSchoolYear);
            }

        }

        private async Task<bool> IsComplexValidationValid(VmSchoolYear vmSchoolYear)
        {

            bool result = false;
            List<SchoolYearsListItemModel> schoolYearItemModels = await _dal.GetSchoolYears(StudentId);
            List<SchoolYear> existingSchoolYears = _mapper.Map<List<SchoolYear>>(schoolYearItemModels);
            SchoolYear postedSchoolYear = _mapper.Map<SchoolYear>(vmSchoolYear);
            var spec = new DuplicateMovieSpecification(postedSchoolYear);

            result = spec.IsSatisfiedBy(existingSchoolYears);

            if (!result)
                ModelState.AddModelError("Year", "This School Year already exists.");

            return result;

        }

        private async Task HandleViewBag(VmSchoolYear vmSchoolYear)
        {

            ViewBag.Courses = vmSchoolYear.Id == null ? null : await _dal.GetCourses(StudentId, (Guid)vmSchoolYear.Id);
            HandleEntityIds(EntityTypes.SchoolYear, vmSchoolYear);

        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {

            await _dal.DeleteSchoolYear(SchoolYearId);

            return RedirectToAction("Detail", "Students", new { sid = StudentId });

        }

    }

}
