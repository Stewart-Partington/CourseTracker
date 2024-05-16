using CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.DeleteSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.UpdateSchoolYear;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearDetail;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList;
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

        [HttpGet]
        public List<SchoolYearsListItemModel> Get()
        {
            return _listQuery.Execute();
        }

        [HttpGet("{id}")]
        public SchoolYearDetailModel Get(Guid id)
        {
            return _detailQuery.Execute(id);
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateSchoolYearModel schoolYear)
        {

            _createCommand.Execute(schoolYear);

            return new HttpResponseMessage(HttpStatusCode.Created);

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