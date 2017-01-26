using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("Locations")]
   public partial class Location
        {

            public int Id { get; set; }
            public bool? Active { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string CountryCode { get; set; }
            public string Name { get; set; }
            public string PostalCode { get; set; }
            public string State { get; set; }
            public string CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }
            public string UpdatedBy { get; set; }
            public string UpdatedDate { get; set; }
            // Navigation property 
            public virtual ICollection<Event> Events { get; set; }


    }
}
