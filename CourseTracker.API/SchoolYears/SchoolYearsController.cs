using CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.DeleteSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.UpdateSchoolYear;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearDetail;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList;
using CourseTracker.Application.Students.Commands.CreateStudent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CourseTracker.API.SchoolYears
{

    [Route("api/[controller]")]
    [ApiController]
    public class SchoolYearsController : ControllerBase
    {

        private readonly IGetSchoolYearsListQuery _listQuery;
        private readonly IGetSchoolYearDetailQuery _detailQuery;
        private readonly ICreateSchoolYearCommand _createCommand;
        private readonly IUpdateSchoolYearCommand _updateCommand;
        private readonly IDeleteSchoolYearCommand _deleteCommand;

        public SchoolYearsController(IGetSchoolYearsListQuery listQuery, IGetSchoolYearDetailQuery detailQuery, ICreateSchoolYearCommand createCommand,
            IUpdateSchoolYearCommand updateCommand, IDeleteSchoolYearCommand deleteCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }

        //[HttpGet("api/Students/{studentId}/SchoolYears")]
        //[Route("api/Students/{studentId:guid}/SchoolYears")]
        //public List<SchoolYearsListItemModel> Get(Guid studentId)
        //{
        //    return _listQuery.Execute(studentId);
        //}

        [HttpGet("{id}")]
        public SchoolYearDetailModel Get(Guid id)
        {
            return _detailQuery.Execute(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSchoolYearModel schoolYear)
        {

            Guid id = await _createCommand.Execute(schoolYear);

            return CreatedAtAction("Get", new { id = id });

        }

        [HttpPut]
        public HttpResponseMessage Update(UpdateSchoolYearModel schoolYear)
        {

            _updateCommand.Execute(schoolYear);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(Guid id)
        {

            _deleteCommand.Execute(id);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

    }

}