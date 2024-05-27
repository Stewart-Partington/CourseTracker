using System.ComponentModel.DataAnnotations;

namespace CourseTracker.UI.SchoolYears.Models
{
    
    public class VmSchoolYear
    {

        public Guid? Id { get; set; }   

        [Required]
        public int? Index { get; set; }

        [Required]
        public int? Year { get; set; }

    }

}
