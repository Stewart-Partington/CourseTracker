using AutoMapper;
using CourseTracker.UI.Models;
using CourseTracker.UI.SchoolYears.Models;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Services.State;
using CourseTracker.UI.Students.Models;
using Microsoft.AspNetCore.Mvc;
using static CourseTracker.UI.Models.Enums;

namespace CourseTracker.UI
{
    
    public class ControllerBase : Controller
    {

        protected readonly IApiDal _dal;
        protected readonly IMapper _mapper;
        protected readonly IState _state;

        public ControllerBase(IApiDal dal, IMapper mapper, IState state)
        {
            _dal = dal;
            _mapper = mapper;
            _state = state;
        }

        public void HandleEntityIds(EntityTypes entityType, object vm)
        {

            EntityIds entityIds = _state.EntityIds == null ? new EntityIds() : _state.EntityIds;

            switch (entityType)
            {

                case EntityTypes.Students:
;
                    entityIds.Student = null;
                    entityIds.SchoolYear = null;
                    entityIds.Course = null;
                    entityIds.Assessment = null;

                    break;

                case EntityTypes.Student:

                    VmStudent vmStudent = (VmStudent)vm;
                    KeyValuePair<Guid?, string> kvpStudent = new KeyValuePair<Guid?, string>(vmStudent.Id, vmStudent.FirstName);

                    entityIds.Student = kvpStudent;
                    entityIds.SchoolYear = null;
                    entityIds.Course = null;
                    entityIds.Assessment = null;

                    break;

                case EntityTypes.SchoolYear:

                    VmSchoolYear vmSchoolYear = (VmSchoolYear)vm;
                    KeyValuePair<Guid?, string> kvpSchoolYear = new KeyValuePair<Guid?, string>(vmSchoolYear.Id, vmSchoolYear.Year.ToString());

                    entityIds.SchoolYear = kvpSchoolYear;
                    entityIds.Course = null;
                    entityIds.Assessment = null;

                    break;

                case EntityTypes.Course:

                    break;

                case EntityTypes.Assessment:

                    break;

            }

            entityIds.EntityType = entityType;
            ViewBag.EntityIds = entityIds;
            _state.EntityIds = entityIds;

        }

    }

}
