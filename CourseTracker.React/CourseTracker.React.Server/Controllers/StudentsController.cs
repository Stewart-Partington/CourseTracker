using CourseTracker.Application.Students.Queries.GetStudentDetail;
using CourseTracker.Application.Students.Queries.GetStudentsList;
using Microsoft.AspNetCore.Mvc;

namespace CourseTracker.React.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {

        private readonly IGetStudentsListQuery _listQuery;
        private readonly IGetStudentDetailQuery _detailQuery;

        public StudentsController(IGetStudentsListQuery listQuery, IGetStudentDetailQuery detailQuery)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
        }

        [HttpGet]
        public ActionResult<List<StudentListItemModel>> Get()
        {
            return _listQuery.Execute();
        }

        [HttpGet("{id?}")] 
        public ActionResult<StudentDetailModel> Get(Guid? id)
        {

            var result = id == Guid.Empty ? new StudentDetailModel() : _detailQuery.Execute((Guid)id);

            return result;

        }

    }

}
