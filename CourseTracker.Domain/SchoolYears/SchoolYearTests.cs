using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseTracker.Domain.Assessments;
using CourseTracker.Domain.Courses;
using NUnit.Framework;

namespace CourseTracker.Domain.SchoolYears
{

    [TestFixture]
    public class SchoolYearTests
    {

        private SchoolYear _schoolYear;

        [SetUp]
        public void SetUp()
        {
            _schoolYear = new SchoolYear();
        }

        [Test]
        public void GetAverage()
        {

            double? average;
            Course course;

            // 2023
            course = new Course();
            course.Assessments.Add(new Assessment() { Grade = 100, Weight = 50 });
            course.Assessments.Add(new Assessment() { Grade = 50, Weight = 50 });
            _schoolYear.Courses.Add(course);
            course = new Course();
            course.Assessments.Add(new Assessment() { Grade = 100, Weight = 75 });
            course.Assessments.Add(new Assessment() { Grade = 50, Weight = 25 });
            _schoolYear.Courses.Add(course);

            Assert.That(_schoolYear.Average, Is.EqualTo(81.3));

        }


    }

}
