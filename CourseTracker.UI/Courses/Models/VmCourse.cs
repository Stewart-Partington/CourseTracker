using System.ComponentModel.DataAnnotations;

namespace CourseTracker.UI.Courses.Models
{
    
    public class VmCourse
    {

        public Guid? Id { get; set; }

        public Guid SchoolYearId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int? Semester { get; set; }

    }

}
