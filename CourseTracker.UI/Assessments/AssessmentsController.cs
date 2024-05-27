using AutoMapper;
using CourseTracker.Application.Assessments.Queries.GetAssementDetail;
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
                EntityIds entityIds = _state.EntityIds;
                AssessmentDetailModel assessmentDetailModel = await _dal.GetAssessment((Guid)entityIds.Student.Value.Key,
                    (Guid)entityIds.SchoolYear.Value.Key, (Guid)entityIds.Course.Value.Key, (Guid)aid);
                result = _mapper.Map<VmAssessment>(assessmentDetailModel);
            }

            HandleEntityIds(EntityTypes.Assessment, result);

            return View(result);

        }

    }
}
