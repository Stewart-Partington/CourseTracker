
using CourseTracker.Application.Attachments.Commands.CreateAttachment;
using CourseTracker.Application.Attachments.Commands.UpdateAttachment;
using CourseTracker.Domain.Attachments;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Commands.Factory
{
    
    public class AttachmentFactory
    {

        public Attachment Create(CreateAttachmentModel model)
        {
            return new Attachment()
            {
                AssessmentId = model.AssessmentId,
                Name = model.Name,
                Type = model.Type,
                Payload = model.Payload,
            };
        }

        public Attachment Create(UpdateAttachmentModel model)
        {
            return new Attachment()
            {
                Id = model.Id,
                AssessmentId = model.AssessmentId,
                Name = model.Name,
                Type = model.Type,
                Payload = model.Payload,
            };
        }

    }

}
