using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Commands.DeleteAttachment
{
    
    public interface IDeleteAttachmentCommand
    {

        void Execute(Guid attachmentId);

    }

}
