using CourseTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Queries.GetAttachmentDetail
{
    
    public class GetAttachmentDetailQuery : IGetAttachmentDetailQuery
    {

        private readonly IDatabaseService _database;

        public GetAttachmentDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public AttachmentDetailModel Execute(Guid attachmentId)
        {

            var result = _database.Attachments
                .Where(x => x.Id == attachmentId)
                .Select(x => new AttachmentDetailModel
                {
                    Id = x.Id,
                    AssessmentId = x.AssessmentId,
                    Name = x.Name,
                    Type = x.Type,
                    Payload = x.Payload,
                })
                .Single();

            return result;

        }

    }

}
