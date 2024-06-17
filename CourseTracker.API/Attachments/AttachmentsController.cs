using CourseTracker.Application.Attachments.Commands.CreateAttachment;
using CourseTracker.Application.Attachments.Commands.DeleteAttachment;
using CourseTracker.Application.Attachments.Commands.UpdateAttachment;
using CourseTracker.Application.Attachments.Queries.GetAttachmentDetail;
using CourseTracker.Application.Attachments.Queries.GetAttachmentList;
using CourseTracker.Domain.Assessments;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CourseTracker.API.Attachments
{

    [Route("api/")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {

        private readonly IGetAttachmentsListQuery _listQuery;
        private readonly IGetAttachmentDetailQuery _detailQuery;
        private readonly ICreateAttachmentCommand _createCommand;
        private readonly IUpdateAttachmentCommand _updateCommand;
        private readonly IDeleteAttachmentCommand _deleteCommand;

        public AttachmentsController(IGetAttachmentsListQuery listQuery, IGetAttachmentDetailQuery detailQuery, ICreateAttachmentCommand createCommand,
            IUpdateAttachmentCommand updateCommand, IDeleteAttachmentCommand deleteCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }

        [HttpGet]
        [Route("Students/{studentId}/SchoolYears/{schoolYearId}/Courses/{courseId}/Assessments/{assessmentId}/Attachments")]
        public ActionResult<List<AttachmentListItemModel>> Get(Guid studentId, Guid schoolYearId, Guid courseId, Guid assessmentId)
        {
            return _listQuery.Execute(assessmentId);
        }

        [HttpGet]
        [Route("Students/{studentId}/SchoolYears/{schoolYearId}/Courses/{courseId}/Assessments/{assessmentId}/Attachments/{attachmentId}")]
        public ActionResult<AttachmentDetailModel> Get(Guid studentId, Guid schoolYearId, Guid courseId, Guid assessmentId, Guid attachmentId)
        {
            return _detailQuery.Execute(attachmentId);
        }

        [HttpPost]
        [Route("Attachments")]
        public async Task<ActionResult<Guid>> Post(CreateAttachmentModel attachment)
        {

            Guid result = await _createCommand.Execute(attachment);

            return Created($"Students/{attachment.StudentId}/SchoolYears/{attachment.SchoolYearId}/Courses/{attachment.CourseId}/Assessments/{attachment.AssessmentId}/Attachments/{result}", result);

        }

        [HttpPut]
        [Route("Attachments")]
        public async Task<ActionResult<HttpResponseMessage>> Update(UpdateAttachmentModel attachment)
        {
            await _updateCommand.ExecuteAsync(attachment);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("Attachments/{id}")]
        public async Task<ActionResult<HttpResponseMessage>> Delete(Guid id)
        {
            await _deleteCommand.ExecuteAsync(id);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }

}
