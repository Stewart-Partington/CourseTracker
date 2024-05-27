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

    [Route("api/")]
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

        [HttpGet]
        [Route("Students/{studentId}/SchoolYears")]
        public List<SchoolYearsListItemModel> Get(Guid studentId)
        {
            return _listQuery.Execute(studentId);
        }

        [HttpGet]
        [Route("Students/{studentId}/SchoolYears/{schoolYearId}")]
        public SchoolYearDetailModel Get(Guid studentId, Guid schoolYearId)
        {
            return _detailQuery.Execute(schoolYearId);
        }

        [HttpPost]
        [Route("SchoolYears")]
        public async Task<IActionResult> Post(CreateSchoolYearModel schoolYear)
        {

            Guid schoolYearId = await _createCommand.Execute(schoolYear);

            return CreatedAtAction("Get", new { studentId = schoolYear.StudentId, schoolYearId = schoolYearId }, schoolYearId);

        }

        [HttpPut]
        [Route("SchoolYears")]
        public HttpResponseMessage Update(UpdateSchoolYearModel schoolYear)
        {

            _updateCommand.Execute(schoolYear);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        [HttpDelete]
        [Route("SchoolYears/{id}")]
        public HttpResponseMessage Delete(Guid id)
        {

            _deleteCommand.Execute(id);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

    }

}