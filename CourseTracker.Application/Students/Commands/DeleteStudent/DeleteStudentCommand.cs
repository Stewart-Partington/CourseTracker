using CourseTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Students.Commands.DeleteStudent
{
	
	public class DeleteStudentCommand : IDeleteStudentCommand
	{

        private readonly IDatabaseService _database;

        public DeleteStudentCommand(IDatabaseService database)
        {
            _database = database;       
        }

        public void Execute(Guid studentId)
        {

            var student = _database.Students.Find(studentId);

            _database.Students.Remove(student);
            _database.Save();

        }

    }

}
