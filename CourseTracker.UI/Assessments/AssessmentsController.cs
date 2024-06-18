using AutoMapper;
using CourseTracker.Application.Assessments.Commands.CreateAssessment;
using CourseTracker.Application.Assessments.Commands.UpdateAssessment;
using CourseTracker.Application.Assessments.Queries.GetAssementDetail;
using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.Application.Courses.Queries.GetCoursesList;
using CourseTracker.Domain.Assessments;
using CourseTracker.Domain.Courses;
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

                if (!await IsComplexValidationValid(vmAssessment))
                {
                    ViewBag.Attachments = vmAssessment.Id == null ? null : await _dal.GetAttachments(StudentId, SchoolYearId, CourseId, AssessmentId);
                    HandleEntityIds(EntityTypes.Assessment, null);
                    return View(vmAssessment);
                }

                Guid aid;

                if (vmAssessment.Id == null)
                {
                    var createAssessment = _mapper.Map<CreateAssessmentModel>(vmAssessment);
                    createAssessment.StudentId = StudentId;
                    createAssessment.SchoolYearId = SchoolYearId;
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
                ViewBag.Attachments = vmAssessment.Id == null ? null : await _dal.GetAttachments(StudentId, SchoolYearId, CourseId, AssessmentId);
                HandleEntityIds(EntityTypes.Assessment, null);
                return View(vmAssessment);
            }

        }

        private async Task<bool> IsComplexValidationValid(VmAssessment vmAssessment)
        {

            bool result = false;
            List<AssessmentsListItemModel> assessmentsListItemModel = await _dal.GetAssessments(StudentId, SchoolYearId, CourseId);
            List<Assessment> existingAssessments = _mapper.Map<List<Assessment>>(assessmentsListItemModel);
            Assessment postedAssessment = _mapper.Map<Assessment>(vmAssessment);

            // Duplicate
            var specDuplicate = new DuplicateAssessmentSpecification(postedAssessment);
            bool duplicateResult = specDuplicate.IsSatisfiedBy(existingAssessments);

            if (!duplicateResult)
            {
                ModelState.AddModelError("Name", "This combination of Name and Assessment Type already exists.");
                ModelState.AddModelError("AssessmentType", "This combination of Name and Assessment Type already exists.");
            }

            // Weight
            if (postedAssessment.Id == Guid.Empty)
                existingAssessments.Add(postedAssessment);
            else
            {
                int index = existingAssessments.FindIndex(x => x.Id == postedAssessment.Id);
                if (index != -1)
                    existingAssessments[index] = postedAssessment;
            }

            var specWeight = new CumulativeAssessmentWeightSpecification();
            bool weightResult = specWeight.IsSatisfiedBy(existingAssessments);

            if (!weightResult)
            {
                ModelState.AddModelError("Weight", "The cumulative weight for this course exceeds 100%");
            }

            result = duplicateResult && weightResult;

            return result;

        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {

            await _dal.DeleteAssessment(AssessmentId);

            return RedirectToAction("Detail", "Courses", new { cid = CourseId });

        }

    }
}
