using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.SchoolYears
{

    [TestFixture]
    public class DuplicateSchoolYearSpecificationTests
    {

        private List<SchoolYear> _schoolYears;

        [SetUp]
        public void SetUp()
        {
            _schoolYears = new List<SchoolYear>();
        }

        [Test]
        public void AddToEmptyListAssertTrue()
        {

            bool result;
            SchoolYear newSchoolYear = new SchoolYear() { Year = 2020, Id = Guid.NewGuid() };
            var spec = new DuplicateSchoolYearSpecification(newSchoolYear);

            result = spec.IsSatisfiedBy(_schoolYears);

            Assert.That(result, Is.True);

        }

        [Test]
        public void AddNewYearToHydratedListAssertTrue()
        {

            bool result;
            SchoolYear newSchoolYear = new SchoolYear() { Year = 2020, Id = Guid.NewGuid() };
            var spec = new DuplicateSchoolYearSpecification(newSchoolYear);

            _schoolYears.Add(new SchoolYear() { Year = 2019, Id = Guid.NewGuid() });
            _schoolYears.Add(new SchoolYear() { Year = 2021, Id = Guid.NewGuid() });
            _schoolYears.Add(new SchoolYear() { Year = 2022, Id = Guid.NewGuid() });
            _schoolYears.Add(new SchoolYear() { Year = 2023, Id = Guid.NewGuid() });

            result = spec.IsSatisfiedBy(_schoolYears);

            Assert.That(result, Is.True);

        }

        [Test]
        public void AddExistingYearToHydratedListAssertFalse()
        {

            bool result;
            SchoolYear newSchoolYear = new SchoolYear() { Year = 2020, Id = Guid.NewGuid() };
            var spec = new DuplicateSchoolYearSpecification(newSchoolYear);

            _schoolYears.Add(new SchoolYear() { Year = 2020, Id = Guid.NewGuid() });
            _schoolYears.Add(new SchoolYear() { Year = 2021, Id = Guid.NewGuid() });
            _schoolYears.Add(new SchoolYear() { Year = 2022, Id = Guid.NewGuid() });
            _schoolYears.Add(new SchoolYear() { Year = 2023, Id = Guid.NewGuid() });

            result = spec.IsSatisfiedBy(_schoolYears);

            Assert.That(result, Is.False);

        }

        [Test]
        public void AddExistingYearWithSameIdToHydratedListAssertTrue()
        {

            bool result;
            Guid sameGuid = Guid.NewGuid();
            SchoolYear newSchoolYear = new SchoolYear() { Year = 2020, Id = sameGuid };
            var spec = new DuplicateSchoolYearSpecification(newSchoolYear);

            _schoolYears.Add(new SchoolYear() { Year = 2020, Id = sameGuid });
            _schoolYears.Add(new SchoolYear() { Year = 2021, Id = Guid.NewGuid() });
            _schoolYears.Add(new SchoolYear() { Year = 2022, Id = Guid.NewGuid() });
            _schoolYears.Add(new SchoolYear() { Year = 2023, Id = Guid.NewGuid() });

            result = spec.IsSatisfiedBy(_schoolYears);

            Assert.That(result, Is.True);

        }

    }

}
