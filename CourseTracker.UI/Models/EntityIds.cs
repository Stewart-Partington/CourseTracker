using static CourseTracker.UI.Models.Enums;

namespace CourseTracker.UI.Models
{
    
    public class EntityIds
    {

        public EntityTypes EntityType { get; set; }

        public KeyValuePair<Guid?, string>? Student { get; set; }

        public KeyValuePair<Guid?, string>? SchoolYear { get; set; }

        public KeyValuePair<Guid?, string>? Course { get; set; }

        public KeyValuePair<Guid?, string>? Assessment { get; set; }

    }

}
