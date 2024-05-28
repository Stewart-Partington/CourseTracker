using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Queries.GetAttachmentList
{
    
    public interface IGetAttachmentsListQuery
    {

        List<AttahcmentListModel> Execute(Guid assessmentId);

    }

}
