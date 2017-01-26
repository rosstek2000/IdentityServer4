using System;

namespace EventManager.Core
{
    public class ListMembership
    {
        public int ListId { get; set; }
        public string MemberId { get; set; }
        public int GroupTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedDate { get; set; }

        // References
        public virtual List List { get; set; }
    }

}
