using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Domain.Assessments
{
    
    [TestFixture]
    public class CumulativeAssessmentWeightSpecificationTests
    {

        private List<Assessment> _assements;

        [SetUp]
        public void SetUp()
        {
            _assements = new List<Assessment>();
        }

        [Test]
        public void EmptyListAssertTrue()
        {

            bool result;
            var spec = new CumulativeAssessmentWeightSpecification();

            result = spec.IsSatisfiedBy(_assements);

            Assert.That(result, Is.True);

        }

        [Test]
        public void AddSingleAssessmentLessThan100AssertTrue()
        {

            bool result;
            var spec = new CumulativeAssessmentWeightSpecification();

            _assements.Add(new Assessment() { Weight = 99 });
            result = spec.IsSatisfiedBy(_assements);

            Assert.That(result, Is.True);

        }

        [Test]
        public void AddMultipleAssessmentLessThan100AssertTrue()
        {

            bool result;
            var spec = new CumulativeAssessmentWeightSpecification();

            _assements.Add(new Assessment() { Weight = 50 });
            _assements.Add(new Assessment() { Weight = 49 });
            result = spec.IsSatisfiedBy(_assements);

            Assert.That(result, Is.True);

        }

        [Test]
        public void AddMultipleAssessmentEquals100AssertTrue()
        {

            bool result;
            var spec = new CumulativeAssessmentWeightSpecification();

            _assements.Add(new Assessment() { Weight = 50 });
            _assements.Add(new Assessment() { Weight = 50 });
            result = spec.IsSatisfiedBy(_assements);

            Assert.That(result, Is.True);

        }

        [Test]
        public void AddSingleAssessmentGreaterThan100AssertFalse()
        {

            bool result;
            var spec = new CumulativeAssessmentWeightSpecification();

            _assements.Add(new Assessment() { Weight = 101 });
            result = spec.IsSatisfiedBy(_assements);

            Assert.That(result, Is.False);

        }

        [Test]
        public void AddMultipleAssessmentGreaterThan100AssertFalse()
        {

            bool result;
            var spec = new CumulativeAssessmentWeightSpecification();

            _assements.Add(new Assessment() { Weight = 50 });
            _assements.Add(new Assessment() { Weight = 51 });
            result = spec.IsSatisfiedBy(_assements);

            Assert.That(result, Is.False);

        }

    }

}
