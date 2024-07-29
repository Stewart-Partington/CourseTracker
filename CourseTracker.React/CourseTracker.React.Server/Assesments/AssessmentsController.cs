using AutoMapper;
using CourseTracker.Application.Assessments.Commands.CreateAssessment;
using CourseTracker.Application.Assessments.Commands.DeleteAssessment;
using CourseTracker.Application.Assessments.Commands.UpdateAssessment;
using CourseTracker.Application.Assessments.Queries.GetAssementDetail;
using CourseTracker.Application.Assessments.Queries.GetAssessmentList;
using CourseTracker.React.Server.Assesments.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseTracker.React.Server.Assesments
{

    [ApiController]
    [Route("api/[controller]")]
    public class AssessmentsController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IGetAssessmentsListQuery _listQuery;
        private readonly IGetAssessmentDetailQuery _detailQuery;
        private readonly ICreateAssessmentCommand _createCommand;
        private readonly IUpdateAssessmentCommand _updateCommand;
        private readonly IDeleteAssessmentCommand _deleteCommand;

        public AssessmentsController(IMapper mapper, IGetAssessmentsListQuery listQuery, IGetAssessmentDetailQuery detailQuery, 
            ICreateAssessmentCommand createCommand, IUpdateAssessmentCommand updateCommand, IDeleteAssessmentCommand deleteCommand)
        {
            _mapper = mapper;
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }

        [HttpGet("{courseId}")]
        public ActionResult<List<AssessmentsListItemModel>> Get(Guid courseId)
        {
            return _listQuery.Execute(courseId);
        }

        [HttpGet("{id}/{courseId}")]
        public ActionResult<VmAssessment> Get(Guid id, Guid courseId)
        {

            VmAssessment result = null;

            if (id == Guid.Empty)
                result = new VmAssessment() { CourseId = courseId };
            else
            {
                AssessmentDetailModel assessmentdDetail = _detailQuery.Execute(id);
                result = _mapper.Map<VmAssessment>(assessmentdDetail);
            }

            return result;

        }

        [HttpPost]
        public async Task<JsonResult> Post(VmAssessment vmAssessment)
        {

            if (ModelState.IsValid)
            {

                Guid result;

                if (vmAssessment.Id == Guid.Empty)
                {
                    var createAssessment = _mapper.Map<CreateAssessmentModel>(vmAssessment);
                    result = await _createCommand.ExecuteAsync(createAssessment);
                }
                else
                {
                    var updateAssessment = _mapper.Map<UpdateAssessmentModel>(vmAssessment);
                    await _updateCommand.ExecuteAsync(updateAssessment);
                    result = updateAssessment.Id;
                }

                return Json(result);
            }
            else
            {
                return null;
            }

        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _deleteCommand.ExecuteAsync(id);
        }

    }

}
