using CourseTracker.Application.Students.Queries.GetStudentsList;
using Microsoft.AspNetCore.Mvc;

namespace CourseTracker.React.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {

        private readonly IGetStudentsListQuery _listQuery;

        public StudentsController(IGetStudentsListQuery listQuery)
        {
            _listQuery = listQuery;
        }

        [HttpGet]
        public ActionResult<List<StudentListItemModel>> Get()
        {

            //throw new Exception("Wups");

            return _listQuery.Execute();
        }

    }

}
