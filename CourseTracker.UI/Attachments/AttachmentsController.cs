using AutoMapper;
using CourseTracker.Application.Attachments.Commands.CreateAttachment;
using CourseTracker.UI.Models;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Services.State;
using CourseTracker.UI.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CourseTracker.UI.Attachments
{

    public class AttachmentsController : BaseController
    {

        public AttachmentsController(IApiDal dal, IMapper mapper, IState state)
            : base(dal, mapper, state)
        {
                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Upload(List<IFormFile> files)
        {

            if (files.Count == 1)
            {

                FormFile formFile = (FormFile)files[0];
                
                if (formFile.Length > 0)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);

                        CreateAttachmentModel createAttachment = new CreateAttachmentModel()
                        {
                            StudentId = StudentId,
                            SchoolYearId = SchoolYearId,
                            CourseId = CourseId,
                            AssessmentId = AssessmentId,
                            Name = Path.GetFileName(formFile.FileName),
                            Type = formFile.ContentType,
                            Payload = memoryStream.ToArray()
                        };

                        _dal.CreateAttachment(createAttachment);

                    }
                }

            }

            return RedirectToAction("Detail", "Assessments", new { aid = AssessmentId });

        }

        [HttpGet]
        public async Task<IActionResult> Download(Guid id)
        {

            EntityIds entityIds = _state.EntityIds;
            var attachment = await _dal.GetAttachment((Guid)entityIds.Student.Value.Key, (Guid)entityIds.SchoolYear.Value.Key, (Guid)entityIds.Course.Value.Key,
                    (Guid)entityIds.Assessment.Value.Key, id);

            if (attachment == null)
                return new EmptyResult();

            MemoryStream stream = new MemoryStream(attachment.Payload);

            return new FileStreamResult(stream, attachment.Type)
            {
                FileDownloadName = attachment.Name
            };

        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(Guid id)
        {

            await _dal.DeleteAttachment(id);

            return new JsonResult(new { result = true, id = id })
            {
                StatusCode = 200
            };

        }

    }

}
