using CourseTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Queries.GetAttachmentList
{
    
    public class GetAttachmentsListQuery : IGetAttachmentsListQuery
    {

        private readonly IDatabaseService _database;

        public GetAttachmentsListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<AttahcmentListModel> Execute(Guid assessmentId)
        {

            var result = _database.Attachments
                .Where(x => x.AssessmentId == assessmentId)
                .Select(x => new AttahcmentListModel()
                {
                    Id = x.Id,
                    AssessmentId = x.AssessmentId,
                    Name = x.Name,
                    Type = x.Type,
                    Payload = x.Payload,
                });

            return result.ToList();

        }

    }

}
