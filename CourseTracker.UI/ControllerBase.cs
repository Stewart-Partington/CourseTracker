using AutoMapper;
using CourseTracker.UI.Assessments.Models;
using CourseTracker.UI.Courses.Models;
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

        private readonly EntityIds _entityIds;

        public ControllerBase(IApiDal dal, IMapper mapper, IState state)
        {
            _dal = dal;
            _mapper = mapper;
            _state = state;

            _entityIds = _state.EntityIds;
        }

        public Guid StudentId
        {
            get
            {
                return (Guid)_entityIds.Student.Value.Key;
            }
        }

        public Guid SchoolYearId
        {
            get
            {
                return (Guid)_entityIds.SchoolYear.Value.Key;
            }
        }

        public Guid CourseId
        {
            get
            {
                return (Guid)_entityIds.Course.Value.Key;
            }
        }

        public Guid AssessmentId
        {
            get
            {
                return (Guid)_entityIds.Assessment.Value.Key;
            }
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

                    VmCourse vmCourse = (VmCourse)vm;
                    KeyValuePair<Guid?, string> kvpCourse = new KeyValuePair<Guid?, string>(vmCourse.Id, vmCourse.Name);

                    entityIds.Course = kvpCourse;
                    entityIds.Assessment = null;

                    break;

                case EntityTypes.Assessment:

                    VmAssessment vmAssessment = (VmAssessment)vm;
                    KeyValuePair<Guid?, string> kvpAssessment = new KeyValuePair<Guid?, string>(vmAssessment.Id, vmAssessment.Name);

                    entityIds.Assessment = kvpAssessment;

                    break;

            }

            entityIds.EntityType = entityType;
            ViewBag.EntityIds = entityIds;
            _state.EntityIds = entityIds;

        }

    }

}
