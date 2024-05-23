using System.ComponentModel.DataAnnotations;

namespace CourseTracker.UI.SchoolYears.Models
{
    
    public class VmSchoolYear
    {

        public Guid Id { get; set; }   

        public Guid StudentId { get; set; }

        [Required]
        public int? Index { get; set; }

        [Required]
        public int? Year { get; set; }

    }

}
