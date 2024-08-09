using AutoMapper;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearsList;
using CourseTracker.Application.SchoolYears.Queries.GetSchoolYearDetail;
using CourseTracker.Application.SchoolYears.Commands.CreateSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.UpdateSchoolYear;
using CourseTracker.Application.SchoolYears.Commands.DeleteSchoolYear;
using Microsoft.AspNetCore.Mvc;
using CourseTracker.React.Server.SchoolYears.Models;
using CourseTracker.Domain.SchoolYears;
using CourseTracker.Domain.Students;

namespace CourseTracker.React.Server.SchoolYears
{

    [ApiController]
    [Route("api/[controller]")]
    public class SchoolYearsController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IGetSchoolYearsListQuery _listQuery;
        private readonly IGetSchoolYearDetailQuery _detailQuery;
        private readonly ICreateSchoolYearCommand _createCommand;
        private readonly IUpdateSchoolYearCommand _updateCommand;
        private readonly IDeleteSchoolYearCommand _deleteCommand;

        public SchoolYearsController(IMapper mapper, IGetSchoolYearsListQuery listQuery, IGetSchoolYearDetailQuery detailQuery,
            ICreateSchoolYearCommand createCommand, IUpdateSchoolYearCommand updateCommand, IDeleteSchoolYearCommand deleteCommand)
        {
            _mapper = mapper;
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }

        [HttpGet("{studentId}")]
        public ActionResult<List<SchoolYearsListItemModel>> Get(Guid studentId)
        {
            return _listQuery.Execute(studentId);
        }

        [HttpGet("{id}/{studentId}")]
        public ActionResult<VmSchoolYear> Get(Guid id, Guid studentId)
        {

            VmSchoolYear result = null;

            if (id == Guid.Empty)
                result = new VmSchoolYear() { StudentId = studentId };
            else
            {
                SchoolYearDetailModel schoolYearDetail = _detailQuery.Execute(id);
                result = _mapper.Map<VmSchoolYear>(schoolYearDetail);
            }

            return result;

        }

        [HttpPost]
        public async Task<IActionResult> Post(VmSchoolYear vmSchoolYear)
        {

            if (ModelState.IsValid)
            {

                if (!IsComplexValidationValid(vmSchoolYear))
                    return ValidationProblem(ModelState);

                Guid result;

                if (vmSchoolYear.Id == Guid.Empty)
                {
                    var createSchoolYear = _mapper.Map<CreateSchoolYearModel>(vmSchoolYear);
                    result = await _createCommand.ExecuteAsync(createSchoolYear);
                }
                else
                {
                    var updateSchoolYear = _mapper.Map<UpdateSchoolYearModel>(vmSchoolYear);
                    await _updateCommand.ExecuteAsync(updateSchoolYear);
                    result = updateSchoolYear.Id;
                }

                return Json(result);
            }
            else
            {
                return null;
            }

        }

        private bool IsComplexValidationValid(VmSchoolYear vmSchoolYear)
        {

            bool result = false;
            List<SchoolYearsListItemModel> schoolYearItemModels = _listQuery.Execute(vmSchoolYear.StudentId); ;
            List<SchoolYear> existingSchoolYears = _mapper.Map<List<SchoolYear>>(schoolYearItemModels);
            SchoolYear postedSchoolYear = _mapper.Map<SchoolYear>(vmSchoolYear);
            var spec = new DuplicateSchoolYearSpecification(postedSchoolYear);

            result = spec.IsSatisfiedBy(existingSchoolYears);

            if (!result)
                ModelState.AddModelError("Year", "This School Year already exists.");

            return result;

        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _deleteCommand.ExecuteAsync(id);
        }

    }

}
