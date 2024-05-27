using CourseTracker.Domain.Assessments;

namespace CourseTracker.UI.Assessments.Models
{
    
    public class VmAssessment
    {

        public Guid? Id { get; set; }

        public Guid? CourseId { get; set; }

        public AssessmentTypes AssessmentType { get; set; }

        public string Name { get; set; }

        public double Grade { get; set; }

        public double Weight { get; set; }

    }

}
