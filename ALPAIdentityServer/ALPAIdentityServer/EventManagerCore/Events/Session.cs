using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("Session")]
    public partial class Session
    {
      

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime EndDateTime { get; set; }
        public int EventId { get; set; }
        public string LocationDetail { get; set; }
        public int MaxGuests { get; set; }
        public int? MaxRegistrants { get; set; }
        public string Name { get; set; }
        public DateTime? RegisterByDate { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Track { get; set; }
        public int Type { get; set; }

    }
}
