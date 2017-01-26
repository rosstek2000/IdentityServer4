using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("AttendeeTypes")]
    public class AttendeeType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
