﻿using AutoMapper;
using CourseTracker.Application.Courses.Commands.CreateCourse;
using CourseTracker.Application.Courses.Commands.DeleteCourse;
using CourseTracker.Application.Courses.Commands.UpdateCourse;
using CourseTracker.Application.Courses.Queries.GetCourseDetail;
using CourseTracker.Application.Courses.Queries.GetCoursesList;
using CourseTracker.Domain.Courses;
using CourseTracker.Domain.SchoolYears;
using CourseTracker.Domain.Students;
using CourseTracker.React.Server.Courses.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseTracker.React.Server.Courses
{

    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IGetCourseListQuery _listQuery;
        private readonly IGetCourseDetailQuery _detailQuery;
        private readonly ICreateCourseCommand _createCommand;
        private readonly IUpdateCourseCommand _updateCommand;
        private readonly IDeleteCourseCommand _deleteCommand;

        public CoursesController(IMapper mapper, IGetCourseListQuery listQuery, IGetCourseDetailQuery detailQuery,
            ICreateCourseCommand createCommand, IUpdateCourseCommand updateCommand, IDeleteCourseCommand deleteCommand)
        {
            _mapper = mapper;
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }

        [HttpGet("{schoolYearId}")]
        public ActionResult<List<CoursesListItemModel>> Get(Guid schoolYearId)
        {
            return _listQuery.Execute(schoolYearId);
        }

        [HttpGet("{id}/{schoolYearId}")]
        public ActionResult<VmCourse> Get(Guid id, Guid schoolYearId)
        {

            VmCourse result = null;

            if (id == Guid.Empty)
                result = new VmCourse() { SchoolYearId = schoolYearId };
            else
            {
                CourseDetailModel courseDetail = _detailQuery.Execute(id);
                result = _mapper.Map<VmCourse>(courseDetail);
            }

            return result;

        }

        [HttpPost]
        public async Task<IActionResult> Post(VmCourse vmCourse)
        {

            if (ModelState.IsValid)
            {

                if (!IsComplexValidationValid(vmCourse))
                    return ValidationProblem(ModelState);

                Guid result;

                if (vmCourse.Id == Guid.Empty)
                {
                    var createCourse = _mapper.Map<CreateCourseModel>(vmCourse);
                    result = await _createCommand.ExecuteAsync(createCourse);
                }
                else
                {
                    var updateCourse = _mapper.Map<UpdateCourseModel>(vmCourse);
                    await _updateCommand.ExecuteAsync(updateCourse);
                    result = updateCourse.Id;
                }

                return Json(result);
            }
            else
            {
                return null;
            }

        }

        private bool IsComplexValidationValid(VmCourse vmCourse)
        {

            bool result = false;
            List<CoursesListItemModel> coursesListItemModel = _listQuery.Execute(vmCourse.SchoolYearId);
            List<Course> existingCourses = _mapper.Map<List<Course>>(coursesListItemModel);
            Course postedCourse = _mapper.Map<Course>(vmCourse);
            var spec = new DuplicateCourseSpecification(postedCourse);

            result = spec.IsSatisfiedBy(existingCourses);

            if (!result)
                ModelState.AddModelError("Name", "This Course already exists.");

            return result;

        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _deleteCommand.ExecuteAsync(id);
        }

    }

}
