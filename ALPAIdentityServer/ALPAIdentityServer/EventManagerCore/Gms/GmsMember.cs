using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("gmsMember")]
    public class GmsMember
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string MemberId { get; set; }
        public DateTime LastUpdated { get; set; }
        public string ListCode { get; set; }
        public string Memo { get; set; }
      
    }
}
