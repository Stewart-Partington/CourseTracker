using AutoMapper;
using CourseTracker.Application.Attachments.Commands.CreateAttachment;
using CourseTracker.UI.Models;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Services.State;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CourseTracker.UI.Attachments
{
    
    public class AttachmentsController : ControllerBase
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

        //[HttpDelete]
        [HttpGet] // For now...
        public async Task<IActionResult> Delete(Guid id)
        {

            await _dal.DeleteAttachment(id);

            return RedirectToAction("Detail", "Assessments", new { aid = AssessmentId });

        }

    }

}
