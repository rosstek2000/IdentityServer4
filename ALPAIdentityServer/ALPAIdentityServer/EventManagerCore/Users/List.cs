using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("Lists")]
    public class List
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Reverse navigation
        public virtual ICollection<ListMembership> ListMemberships { get; set; }

        public List()
        {
            ListMemberships = new List<ListMembership>();
        }
    }

}
