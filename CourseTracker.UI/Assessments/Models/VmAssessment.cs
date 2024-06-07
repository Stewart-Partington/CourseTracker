using CourseTracker.Domain.Assessments;
using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace CourseTracker.UI.Assessments.Models
{
    
    public class VmAssessment
    {

        public Guid? Id { get; set; }

        public Guid CourseId { get; set; }

        [Required]
        public AssessmentTypes? AssessmentType { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double? Grade { get; set; }

        [Required]
        public double? Weight { get; set; }

        public string? Notes { get; set; }

    }

}
