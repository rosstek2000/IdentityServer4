using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("Badges")]
    public class Badge
    {
        public int Id { get; set; }
        public string BadgeName { get; set; }
        public string BadgePosition { get; set; }
        public string BadgeTitle { get; set; }
        public bool BadgeGenerated { get; set; }
        public bool BadgeActive { get; set; }
        // Navigation property 
        public virtual ICollection<Attendee> Attendees { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }

    }
}
