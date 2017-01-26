using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("Events")]
    public class Event    {
        public int Id { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public DateTime? DefaultCheckInDate { get; set; }
        public DateTime? DefaultCheckOutDate { get; set; }
        public string DetailsHtml { get; set; }
        public string EligibleGroup { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsConcurrentSessionAllowed { get; set; }
        public int LocationId { get; set; }
        public int MaxGuestsPerAttendee { get; set; }
        public int? MaxRegistrants { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime StartDate { get; set; }
        public int EventTypeId { get; set; }
        public string UrlName { get; set; }
        public string GMSListCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Attendee> Attendees { get; set; }
    }
}
