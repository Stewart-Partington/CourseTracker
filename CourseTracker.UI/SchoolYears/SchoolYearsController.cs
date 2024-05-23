using AutoMapper;
using CourseTracker.UI.SchoolYears.Models;
using CourseTracker.UI.Services.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CourseTracker.UI.SchoolYears
{

    public class SchoolYearsController : Controller
    {

        private readonly IApiDal _dal;
        private readonly IMapper _mapper;

        public SchoolYearsController(IApiDal dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? syid)
        {

            VmSchoolYear result = null;

            if (syid == null)
                result = new VmSchoolYear();

            //result.StudentId = 

            return View(result);

        }

    }

}
