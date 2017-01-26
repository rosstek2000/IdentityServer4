using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.ViewModels
{
    public class GMSMemberDataViewModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string ALPA_ID { get; set; }
        public string FRST_NAME { get; set; }
        public string LST_NAME { get; set; }
        public string MEC_CD { get; set; }
        public string Title { get; set; }
        public string Memo { get; set; }
        public string Council { get; set; }
        public string Rep_Position { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
