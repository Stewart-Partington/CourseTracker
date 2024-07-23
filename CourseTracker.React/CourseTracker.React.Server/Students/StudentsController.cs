using AutoMapper;
using CourseTracker.Application.Assessments.Commands.DeleteAssessment;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Application.Students.Commands.DeleteStudent;
using CourseTracker.Application.Students.Commands.UpdateStudent;
using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.Application.Students.Queries.GetStudentsList;
using CourseTracker.React.Server.Students.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseTracker.React.Server.Students
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IGetStudentsListQuery _listQuery;
        private readonly IGetStudentDetailQuery _detailQuery;
        private readonly ICreateStudentCommand _createCommand;
        private readonly IUpdateStudentCommand _updateCommand;
        private readonly IDeleteStudentCommand _deleteCommand;

        public StudentsController(IMapper mapper, IGetStudentsListQuery listQuery, IGetStudentDetailQuery detailQuery, ICreateStudentCommand createCommand,
            IUpdateStudentCommand updateCommand, IDeleteStudentCommand deleteCommand)
        {
            
            _mapper = mapper;
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand; 

        }

        [HttpGet]
        public ActionResult<List<StudentListItemModel>> Get()
        {
            return _listQuery.Execute();
        }

        [HttpGet("{id}")]
        public ActionResult<VmStudent> Get(Guid id)
        {

            VmStudent result = null;

            if (id == Guid.Empty)
                result = new VmStudent();
            else
            {
                StudentDetailModel studentDetail = _detailQuery.Execute(id);
                result = _mapper.Map<VmStudent>(studentDetail);
            }

            return result;

        }

        [HttpPost]
        public async Task<JsonResult> Post(VmStudent vmStudent)
        {

            if (ModelState.IsValid)
            {

                Guid result;

                if (vmStudent.Id == Guid.Empty)
                {
                    var createStudent = _mapper.Map<CreateStudentModel>(vmStudent);
                    result = await _createCommand.ExecuteAsync(createStudent);
                }
                else
                {
                    var updateStudent = _mapper.Map<UpdateStudentModel>(vmStudent);
                    await _updateCommand.ExecuteAsync(updateStudent);
                    result = updateStudent.Id;
                }

                return Json(result);
            }
            else
            {
                return null;
            }

        }

        [HttpDelete]
        public async Task DeleteAssessmentCommand(Guid id)
        {
            await _deleteCommand.ExecuteAsync(id);
        }

    }
}
