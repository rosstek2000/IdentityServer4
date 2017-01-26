using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("EventAttachments")]
    public partial class EventAttachment
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }

      
    }
}
