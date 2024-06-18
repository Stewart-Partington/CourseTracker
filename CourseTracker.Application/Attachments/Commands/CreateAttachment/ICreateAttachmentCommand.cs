using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Commands.CreateAttachment
{
    
    public interface ICreateAttachmentCommand
    {

        Task<Guid> ExecuteAsync(CreateAttachmentModel model);

    }

}
