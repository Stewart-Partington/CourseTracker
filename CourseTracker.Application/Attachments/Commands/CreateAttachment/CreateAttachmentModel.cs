using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Commands.CreateAttachment
{
    
    public class CreateAttachmentModel
    {

        public Guid AssessmentId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public byte[] Payload { get; set; }

    }

}
