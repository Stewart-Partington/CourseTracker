using System.ComponentModel.DataAnnotations;

namespace CourseTracker.React.Server.SchoolYears.Models
{
    
    public class VmSchoolYear
    {

        public Guid? Id { get; set; } = Guid.Empty;

        [Required]
        public int? Index { get; set; } = null;

        [Required]
        [Display(Name = "Year")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "InvalidYear")]
        public int? Year { get; set; } = null;

        public double? Average { get; set; }

    }

}
