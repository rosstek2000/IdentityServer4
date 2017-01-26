using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("ReportParameters")]
    public class ReportParameter
    {
        public int id { get; set; }
        public int reportId { get; set; }
        public string name { get; set; }
        public string sqlType { get; set; }
        public string sqlValue { get; set; }
        public Report report { get; set; }
    }

}