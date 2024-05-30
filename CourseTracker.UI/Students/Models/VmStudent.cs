using System.ComponentModel.DataAnnotations;

namespace CourseTracker.UI.Students.Models
{
    
    public class VmStudent
    {

        public Guid? Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ProgramName { get; set; }

        public double? Average { get; set; }

    }

}
