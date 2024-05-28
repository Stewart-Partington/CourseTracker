using CourseTracker.Application.Attachments.Commands.Factory;
using CourseTracker.Application.Interfaces;
using CourseTracker.Domain.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Commands.CreateAttachment
{
    
    public class CreateAttachmentCommand : ICreateAttachmentCommand
    {

        private readonly IDatabaseService _database;
        public readonly IAttachmentFactory _factory;

        public CreateAttachmentCommand(IDatabaseService database, IAttachmentFactory factory)
        {
            _database = database;
            _factory = factory;
        }

        public async Task<Guid> Execute(CreateAttachmentModel model)
        {

            Guid result = Guid.Empty;
            Attachment attachment = _factory.Create(model);

            result = await _database.InsertAsync<Attachment>(attachment);

            return result;

        }

    }

}
