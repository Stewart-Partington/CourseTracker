﻿using System.ComponentModel.DataAnnotations;

namespace CourseTracker.React.Server.Courses.Models
{
    
    public class VmCourse
    {

        public Guid? Id { get; set; } = Guid.Empty;

        public Guid SchoolYearId { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Semester { get; set; }

        public double Grade { get; set; }

        public string? Notes { get; set; }

    }

}
