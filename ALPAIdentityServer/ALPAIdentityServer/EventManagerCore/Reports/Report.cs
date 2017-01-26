using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("Reports")]
    public class Report
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string storedProcName { get; set; }
        
    }
}
