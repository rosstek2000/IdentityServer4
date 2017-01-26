using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManager.ViewModels
{
    public class AttendeeRegistrationViewModel
    {
        public int AttendeeId { get; set; }
        public string ReportDataName { get; set; }
        public string RequiredText { get; set; }
        public string Value { get; set; }
        public bool RequiredQuestion { get; set; }
        public bool? RegisterComplete { get; set; }
        public DateTime? RegisterCompleteDate { get; set; }
        public string EventName { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public int EventId { get; set; }

    }
}