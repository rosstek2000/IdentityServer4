using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManager.ViewModels
{
    public class GuestViewModel
    {
        public int Id { get; set; }
        public int AttendeeId { get; set; }
        public int? BadgeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string EmailAddress { get; set; }
        public string Comments { get; set; }
        public bool Attended { get; set; }
    }
}