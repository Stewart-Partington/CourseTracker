using CourseTracker.Domain.Assessments;
using System.ComponentModel.DataAnnotations;

namespace CourseTracker.React.Server.Assesments.Models
{
    
    public class VmAssessment
    {

        public Guid? Id { get; set; } = Guid.Empty;

        public Guid CourseId { get; set; }

        [Required]
        public AssessmentTypes? AssessmentType { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        //[Required]
        public double? Grade { get; set; }

        //[Required]
        public double? Weight { get; set; }

        public string? Notes { get; set; } = string.Empty;

    }

}
