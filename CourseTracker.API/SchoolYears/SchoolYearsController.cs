﻿using AutoMapper;
using CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.DeleteSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.UpdateSchoolYear;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearDetail;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList;
using CourseTracker.Application.Students.Commands.CreateStudent;
using CourseTracker.Domain.SchoolYears;
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
        private readonly IMapper _mapper;

        public SchoolYearsController(IGetSchoolYearsListQuery listQuery, IGetSchoolYearDetailQuery detailQuery, ICreateSchoolYearCommand createCommand,
            IUpdateSchoolYearCommand updateCommand, IDeleteSchoolYearCommand deleteCommand, IMapper mapper)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
            _mapper = mapper;
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
        public async Task<Guid> Post(CreateSchoolYearModel schoolYear)
        {

            List<SchoolYearsListItemModel> schoolYearItemModels = _listQuery.Execute(schoolYear.StudentId);
            List<SchoolYear> schoolYears = _mapper.Map<List<SchoolYear>>(schoolYearItemModels);
            var spec = new DuplicateMovieSpecification(schoolYear.Year);

            if (!spec.IsSatisfiedBy(schoolYears))
                throw new DuplicateMovieException();

            Guid result = await _createCommand.Execute(schoolYear);

            return result;

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