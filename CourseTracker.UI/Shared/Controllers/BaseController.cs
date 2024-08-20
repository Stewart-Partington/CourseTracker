using AutoMapper;
using CourseTracker.UI.Assessments.Models;
using CourseTracker.UI.Courses.Models;
using CourseTracker.UI.Models;
using CourseTracker.UI.SchoolYears.Models;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Services.State;
using CourseTracker.UI.Shared.Exceptions;
using CourseTracker.UI.Students.Models;
using Microsoft.AspNetCore.Mvc;
using static CourseTracker.UI.Models.Enums;

namespace CourseTracker.UI.Shared.Controllers
{

    public class BaseController : Controller
    {

        #region Declarations

        protected readonly IApiDal _dal;
        protected readonly IMapper _mapper;
        protected readonly IState _state;

        private readonly EntityIds _entityIds;

        #endregion

        #region Constructors

        public BaseController(IApiDal dal, IMapper mapper, IState state)
        {
            _dal = dal;
            _mapper = mapper;
            _state = state;

            _entityIds = _state.EntityIds;
        }

        #endregion

        #region Public Properties

        public Guid StudentId
        {
            get
            {
                try
                {
                    return (Guid)_entityIds.Student.Value.Key;
                }
                catch
                {
                    throw new InvalidEntityIdException();
                }
            }
        }

        public Guid SchoolYearId
        {
            get
            {
                try
                {
                    return (Guid)_entityIds.SchoolYear.Value.Key;
                }
                catch
                {
                    throw new InvalidEntityIdException();
                }
            }
        }

        public Guid CourseId
        {
            get
            {
                try
                {
                    return (Guid)_entityIds.Course.Value.Key;
                }
                catch
                {
                    throw new InvalidEntityIdException();
                }
            }
        }

        public Guid AssessmentId
        {
            get
            {
                try
                {
                    return (Guid)_entityIds.Assessment.Value.Key;
                }
                catch
                {
                    throw new InvalidEntityIdException();
                }
            }
        }

        #endregion

        #region Protected Methods

        protected void HandleEntityIds(EntityTypes entityType, object vm)
        {

            EntityIds entityIds = _state.EntityIds == null ? new EntityIds() : _state.EntityIds;

            if (vm != null)
            {
                switch (entityType)
                {

                    case EntityTypes.Students:

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
            }

            entityIds.EntityType = entityType;
            ViewBag.EntityIds = entityIds;
            _state.EntityIds = entityIds;

        }

        #endregion

        #region Public Action Methods

        [HttpGet]
        public PartialViewResult ConfirmDeleteModal(Guid id)
        {

            return PartialView("ConfirmDeleteModal", id);

        }

        #endregion

    }

}
