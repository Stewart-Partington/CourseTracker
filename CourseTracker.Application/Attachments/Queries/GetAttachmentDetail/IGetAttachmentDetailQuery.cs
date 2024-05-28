using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Queries.GetAttachmentDetail
{
    
    public interface IGetAttachmentDetailQuery
    {

        AttachmentDetailModel Execute(Guid attachmentId);

    }

}
