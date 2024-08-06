using CourseTracker.Application.Attachments.Commands.CreateAttachment;
using CourseTracker.Application.Attachments.Commands.DeleteAttachment;
using CourseTracker.Application.Attachments.Commands.UpdateAttachment;
using CourseTracker.Application.Attachments.Queries.GetAttachmentDetail;
using CourseTracker.Application.Attachments.Queries.GetAttachmentList;
using CourseTracker.Domain.Assessments;
using CourseTracker.Domain.Courses;
using CourseTracker.Domain.SchoolYears;
using CourseTracker.Domain.Students;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CourseTracker.React.Server.Attachments
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttachmentsController : Controller
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
        [Route("{assessmentId}")]
        public ActionResult<List<AttachmentListItemModel>> Get(Guid assessmentId)
        {
            return _listQuery.Execute(assessmentId);
        }

        [HttpGet]
        [Route("{assessmentId}/{attachmentId}")]
        public ActionResult<AttachmentDetailModel> Get(Guid assessmentId, Guid attachmentId)
        {
            
            AttachmentDetailModel result =  _detailQuery.Execute(attachmentId);

            if (result == null)
                return new EmptyResult();

            MemoryStream stream = new MemoryStream(result.Payload);

            return new FileStreamResult(stream, result.Type)
            {
                FileDownloadName = result.Name
            };

        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(IFormFile file)
        {

            Guid result = Guid.Empty;

            if (file != null)
            {

                FormFile formFile = (FormFile)file;
                Guid studentId = Guid.Parse(Request.Headers["studentid"][0]);
                Guid schoolYearId = Guid.Parse(Request.Headers["schoolyearid"][0]);
                Guid courseId = Guid.Parse(Request.Headers["courseid"][0]);
                Guid assessmentId = Guid.Parse(Request.Headers["assessmentid"][0]);

                if (formFile.Length > 0)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);

                        CreateAttachmentModel createAttachment = new CreateAttachmentModel()
                        {
                            StudentId = studentId,
                            SchoolYearId = schoolYearId,
                            CourseId = courseId,
                            AssessmentId = assessmentId,
                            Name = Path.GetFileName(formFile.FileName),
                            Type = formFile.ContentType,
                            Payload = memoryStream.ToArray()
                        };

                        result = await _createCommand.ExecuteAsync(createAttachment);

                    }
                }

            }

            return Created($"/Attachments/{result}", result);

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
