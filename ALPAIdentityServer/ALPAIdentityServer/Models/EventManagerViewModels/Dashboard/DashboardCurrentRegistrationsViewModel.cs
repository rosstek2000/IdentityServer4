using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManager.ViewModels
{
    public class DashboardCurrentRegistrationsViewModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string ALPANumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public DateTime? RegisterStarted { get; set; }
        public DateTime? RegisterCompleteDate { get; set; }
        public string Value { get; set; }
        public string ProxyUser { get; set; }
        public string Email { get; set; }
        public string ReportDataName { get; set; }
        public string AttendeeTypeId { get; set; }
        public int ListId { get; set; }
        public string AttendeeTypeName { get; set; }
        public string Memo { get; set; }

    }
}