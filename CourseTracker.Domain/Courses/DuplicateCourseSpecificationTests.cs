using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Courses
{

    [TestFixture]
    public class DuplicateCourseSpecificationTests
    {

        private List<Course> _courses;

        [SetUp]
        public void SetUp()
        {
            _courses = new List<Course>();
        }

        [Test]
        public void AddToEmptyListAssertTrue()
        {

            bool result;
            Course newCourse = new Course() { Name = "test1", Id = Guid.NewGuid() };
            var spec = new DuplicateCourseSpecification(newCourse);

            result = spec.IsSatisfiedBy(_courses);

            Assert.That(result, Is.True);

        }

        [Test]
        public void AddNewCourseToHydratedListAssertTrue()
        {

            bool result;
            Course newCourse = new Course() { Name = "test1", Id = Guid.NewGuid() };
            var spec = new DuplicateCourseSpecification(newCourse);

            _courses.Add(new Course() { Name = "test2", Id = Guid.NewGuid() });
            _courses.Add(new Course() { Name = "test3", Id = Guid.NewGuid() });
            _courses.Add(new Course() { Name = "test4", Id = Guid.NewGuid() });
            _courses.Add(new Course() { Name = "test5", Id = Guid.NewGuid() });

            result = spec.IsSatisfiedBy(_courses);

            Assert.That(result, Is.True);

        }

        [Test]
        public void AddExistingCourseToHydratedListAssertFalse()
        {

            bool result;
            Course newCourse = new Course() { Name = "test1", Id = Guid.NewGuid() };
            var spec = new DuplicateCourseSpecification(newCourse);

            _courses.Add(new Course() { Name = "test1", Id = Guid.NewGuid() });
            _courses.Add(new Course() { Name = "test2", Id = Guid.NewGuid() });
            _courses.Add(new Course() { Name = "test3", Id = Guid.NewGuid() });
            _courses.Add(new Course() { Name = "test4", Id = Guid.NewGuid() });

            result = spec.IsSatisfiedBy(_courses);

            Assert.That(result, Is.False);

        }

        [Test]
        public void AddExistingCourseWithSameIdToHydratedListAssertTrue()
        {

            bool result;
            Guid sameGuid = Guid.NewGuid();
            Course newCourse = new Course() { Name = "test1", Id = sameGuid };
            var spec = new DuplicateCourseSpecification(newCourse);

            _courses.Add(new Course() { Name = "test1", Id = sameGuid });
            _courses.Add(new Course() { Name = "test2", Id = Guid.NewGuid() });
            _courses.Add(new Course() { Name = "test3", Id = Guid.NewGuid() });
            _courses.Add(new Course() { Name = "test4", Id = Guid.NewGuid() });

            result = spec.IsSatisfiedBy(_courses);

            Assert.That(result, Is.True);

        }

    }

}
