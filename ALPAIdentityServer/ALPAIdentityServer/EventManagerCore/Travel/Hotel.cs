using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("Hotels")]
    public partial class Hotel
    {
     

        public int Id { get; set; }
        public int EventId { get; set; }
        public int LocationId { get; set; }

    }
}
