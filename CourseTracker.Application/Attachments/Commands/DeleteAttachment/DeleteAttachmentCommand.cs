using CourseTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Attachments.Commands.DeleteAttachment
{
    
    public class DeleteAttachmentCommand : IDeleteAttachmentCommand
    {

        private readonly IDatabaseService _database;

        public DeleteAttachmentCommand(IDatabaseService database)
        {
            _database = database;
        }

        public void Execute(Guid attachmentId)
        {

            var attachment = _database.Attachments.Find(attachmentId);

            _database.Attachments.Remove(attachment);
            _database.Save();

        }

    }

}
