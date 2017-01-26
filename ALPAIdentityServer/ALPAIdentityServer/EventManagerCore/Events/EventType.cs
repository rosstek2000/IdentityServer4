using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("EventTypes")]
    public partial class EventType
    {
        public int Id { get; set; }
        public bool? Active { get; set; }
        public string AdminRoles { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        // Navigation property 
        public virtual ICollection<Event> Events { get; set; }


    }
}
