using CourseTracker.Application.Attachments.Commands.Factory;
using CourseTracker.Application.Interfaces;
using CourseTracker.Domain.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Commands.UpdateAttachment
{
    
    public class UpdateAttachmentCommand : IUpdateAttachmentCommand
    {

        private readonly IDatabaseService _database;
        private readonly IAttachmentFactory _factory;

        public UpdateAttachmentCommand(IDatabaseService database, IAttachmentFactory factory)
        {
            _database = database;
            _factory = factory;
        }

        public void Execute(UpdateAttachmentModel model) {

            Attachment attachment = _factory.Create(model);

            _database.Attachments.Update(attachment);
            _database.Save();
        
        }

    }

}
