using System.ComponentModel.DataAnnotations;

namespace CourseTracker.React.Server.Students.Models
{
    
    public class VmStudent
    {

        public Guid? Id { get; set; } = Guid.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;


        [Required]
        public string ProgramName { get; set; } = string.Empty;


        public double? Average { get; set; }


    }

}
