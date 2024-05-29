using AutoMapper;
using CourseTracker.Application.Assessments.Commands.CreateAssessment;
using CourseTracker.Application.Assessments.Commands.UpdateAssessment;
using CourseTracker.Application.Assessments.Queries.GetAssementDetail;
using CourseTracker.Application.Courses.Commands.CreateCourse;
using CourseTracker.Application.Courses.Commands.UpdateCourse;
using CourseTracker.Application.Courses.Queries.GetCourseDetail;
using CourseTracker.UI.Assessments.Models;
using CourseTracker.UI.Courses.Models;
using CourseTracker.UI.Models;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Services.State;
using Microsoft.AspNetCore.Mvc;
using static CourseTracker.UI.Models.Enums;

namespace CourseTracker.UI.Assessments
{
    public class AssessmentsController : ControllerBase
    {

        public AssessmentsController(IApiDal dal, IMapper mapper, IState state)
            : base(dal, mapper, state)
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? aid)
        {

            VmAssessment result = null;

            if (aid == null)
                result = new VmAssessment();
            else
            {
                AssessmentDetailModel assessmentDetailModel = await _dal.GetAssessment(StudentId, SchoolYearId, CourseId, (Guid)aid);
                result = _mapper.Map<VmAssessment>(assessmentDetailModel);
                ViewBag.Attachments = await _dal.GetAttachments(StudentId, SchoolYearId, CourseId, (Guid)aid);
            }

            HandleEntityIds(EntityTypes.Assessment, result);

            return View(result);

        }

        [HttpPost]
        public async Task<IActionResult> Detail(VmAssessment vmAssessment)
        {

            if (ModelState.IsValid)
            {

                Guid aid;

                if (vmAssessment.Id == null)
                {
                    var createAssessment = _mapper.Map<CreateAssessmentModel>(vmAssessment);
                    createAssessment.CourseId = CourseId;
                    aid = await _dal.CreateAssessment(createAssessment);
                }
                else
                {
                    var updateAssessment = _mapper.Map<UpdateAssessmentModel>(vmAssessment);
                    updateAssessment.CourseId = CourseId;
                    await _dal.UpdateAssessment(updateAssessment);
                    aid = updateAssessment.Id;
                }

                return RedirectToAction("Detail", "Assessments", new { aid = aid });

            }
            else
            {
                ViewBag.Attachments = await _dal.GetAttachments(StudentId, SchoolYearId, CourseId, AssessmentId);
                HandleEntityIds(EntityTypes.Assessment , vmAssessment);
                return View(vmAssessment);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {

            await _dal.DeleteAssessment(AssessmentId);

            return RedirectToAction("Detail", "Courses", new { cid = CourseId });

        }

    }
}
