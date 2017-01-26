using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("Member")]
    public class Member
    {
        [Key]
        public string ALPA_ID { get; set; }
        public string FRST_NAME { get; set; }
        public string LST_NAME { get; set; }
        public string MEC_CD { get; set; }
        public string Memo { get; set; }
        public string BASE_LEC_CD { get; set; }
        public string CLASS_CD { get; set; }
    }

}
