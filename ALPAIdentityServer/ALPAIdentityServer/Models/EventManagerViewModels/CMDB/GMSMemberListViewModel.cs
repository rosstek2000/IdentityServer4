using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Web.ViewModels.CMDB
{
    public class GMSMemberListViewModel
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string MemberId { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Memo { get; set; }
    }
}
