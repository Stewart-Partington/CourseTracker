using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Assessments
{

    [TestFixture]
    public class DuplicateAssessmentSpecificationTests
    {

        private List<Assessment> _assements;

        [SetUp]
        public void SetUp()
        {
            _assements = new List<Assessment>();
        }

        [Test]
        public void AddToEmptyListAssertTrue()
        {

            bool result;
            Assessment newAssessment = new Assessment() { Name = "test1", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() };
            var spec = new DuplicateAssessmentSpecification(newAssessment);

            result = spec.IsSatisfiedBy(_assements);

            Assert.That(result, Is.True);

        }

        [Test]
        public void AddNewAssessmentToHydratedListAssertTrue()
        {

            bool result;
            Assessment newAssessment = new Assessment() { Name = "test1", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() };
            var spec = new DuplicateAssessmentSpecification(newAssessment);

            _assements.Add(new Assessment() { Name = "test2", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });
            _assements.Add(new Assessment() { Name = "test3", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });
            _assements.Add(new Assessment() { Name = "test4", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });
            _assements.Add(new Assessment() { Name = "test5", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });

            result = spec.IsSatisfiedBy(_assements);

            Assert.That(result, Is.True);

        }

        [Test]
        public void AddExistingAssessmentToHydratedListAssertFalse()
        {

            bool result;
            Assessment newAssessment = new Assessment() { Name = "test1", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() };
            var spec = new DuplicateAssessmentSpecification(newAssessment);

            _assements.Add(new Assessment() { Name = "test1", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });
            _assements.Add(new Assessment() { Name = "test2", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });
            _assements.Add(new Assessment() { Name = "test3", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });
            _assements.Add(new Assessment() { Name = "test4", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });

            result = spec.IsSatisfiedBy(_assements);

            Assert.That(result, Is.False);

        }

        [Test]
        public void AddExistingAssessmentWithSameIdToHydratedListAssertTrue()
        {

            bool result;
            Guid sameGuid = Guid.NewGuid();
            Assessment newAssessment = new Assessment() { Name = "test1", AssessmentType = AssessmentTypes.Assignment, Id = sameGuid };
            var spec = new DuplicateAssessmentSpecification(newAssessment);

            _assements.Add(new Assessment() { Name = "test1", AssessmentType = AssessmentTypes.Assignment, Id = sameGuid });
            _assements.Add(new Assessment() { Name = "test2", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });
            _assements.Add(new Assessment() { Name = "test3", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });
            _assements.Add(new Assessment() { Name = "test4", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });

            result = spec.IsSatisfiedBy(_assements);

            Assert.That(result, Is.True);

        }

        [Test]
        public void AddNewAssignmentToHydrateListWithSameNameDifferentAssessmentTypeAssertTrue()
        {

            bool result;
            Assessment newAssessment = new Assessment() { Name = "test1", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() };
            var spec = new DuplicateAssessmentSpecification(newAssessment);

            _assements.Add(new Assessment() { Name = "test1", AssessmentType = AssessmentTypes.Exam, Id = Guid.NewGuid() });
            _assements.Add(new Assessment() { Name = "test2", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });
            _assements.Add(new Assessment() { Name = "test3", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });
            _assements.Add(new Assessment() { Name = "test4", AssessmentType = AssessmentTypes.Assignment, Id = Guid.NewGuid() });

            result = spec.IsSatisfiedBy(_assements);

            Assert.That(result, Is.True);

        }

    }

}
