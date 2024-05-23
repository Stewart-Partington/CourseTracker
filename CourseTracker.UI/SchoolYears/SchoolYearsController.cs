using AutoMapper;
using CourseTracker.UI.SchoolYears.Models;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Services.State;
using Microsoft.AspNetCore.Mvc;

namespace CourseTracker.UI.SchoolYears
{

    public class SchoolYearsController : ControllerBase
    {

        public SchoolYearsController(IApiDal dal, IMapper mapper, IState state)
            : base(dal, mapper, state)
        {

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
