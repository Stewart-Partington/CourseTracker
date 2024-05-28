using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Attachments
{
    
    public class Attachment : EntityBase
    {

        public Guid AssessmentId { get; set; }

        public string Name { get; set; }   

        public string Type { get; set; }

        public byte[] Payload { get; set; }

    }

}
