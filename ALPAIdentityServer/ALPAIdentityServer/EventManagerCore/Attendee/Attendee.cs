using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("Attendees")]
    public class Attendee
    {       
        public int Id { get; set; }
        public string AttendeeTypeId { get; set; }
        public string ALPANumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public string Council { get; set; }
        public string RepPosition { get; set; }
        public int EventId { get; set; }
        public int? BadgeId { get; set; }
        public bool Attended { get; set; }
        public bool ProxyLogin { get; set; }
        public string ProxyUser { get; set; }
        public DateTime? RegisterCompleteDate { get; set; }
        public bool? RegisterComplete { get; set; }
        public DateTime? RegisterStarted { get; set; }
        public List<Guest> Guests { get; set; }
    }
}
