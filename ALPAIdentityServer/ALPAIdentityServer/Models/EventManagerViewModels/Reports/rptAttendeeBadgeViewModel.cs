using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManager.ViewModels
{
    public class rptAttendeeBadgeViewModel
    {
       
        public int id { get; set; }
        
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string BADGENAME { get; set; }
        public string ORGANIZATION { get; set; }
        public string BADGEPOSITION { get; set; }
        public string COUNCILNUMBER { get; set; }
        public string COUNCILLOCATION { get; set; }
        public bool BADGEGENERATED { get; set; }

    }
}
