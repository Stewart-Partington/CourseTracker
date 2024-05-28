using CourseTracker.Application.Attachments.Commands.CreateAttachment;
using CourseTracker.Application.Attachments.Commands.UpdateAttachment;
using CourseTracker.Domain.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Commands.Factory
{
    
    public interface IAttachmentFactory
    {

        Attachment Create(CreateAttachmentModel model);

        Attachment Create(UpdateAttachmentModel model);

    }

}
