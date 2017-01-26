using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("EventPrerequisites")]
    public partial class EventPrerequisite
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Grouping { get; set; }
        public int? PrerequisiteEventId { get; set; }
        public string PrerequisiteEventName { get; set; }
        public int? PrerequisiteSessionId { get; set; }
        public string PrerequisiteSessionName { get; set; }

    }
}
