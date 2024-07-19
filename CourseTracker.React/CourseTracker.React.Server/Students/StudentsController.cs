using AutoMapper;
using CourseTracker.Application.Students.Commands.CreateStudent;
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

        public StudentsController(IMapper mapper, IGetStudentsListQuery listQuery, IGetStudentDetailQuery detailQuery, ICreateStudentCommand createCommand,
            IUpdateStudentCommand updateCommand)
        {
            
            _mapper = mapper;
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;

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
        public async Task<IActionResult> Post(VmStudent vmStudent)
        {

            if (ModelState.IsValid)
            {

                Guid result;

                if (vmStudent.Id == null)
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

                return RedirectToAction("Detail", "Students", new { sid = result });
            }
            else
            {
                //ViewBag.SchoolYears = await _dal.GetSchoolYears((Guid)vmStudent.Id);
                //HandleEntityIds(EntityTypes.Student, null);
                //return View(vmStudent);

                return null;

            }

        }

    }
}
