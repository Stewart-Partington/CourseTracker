using CourseTracker.Application.Assessments.Commands.UpdateAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Commands.UpdateAttachment
{
    
    public interface IUpdateAttachmentCommand
    {

        void Execute(UpdateAttachmentModel model);

    }

}
