using EventManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.ViewModels
{
    public class EventViewModel
    {
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int LocationId { get; set; }
        public int? MaxRegistrants { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public bool IsConcurrentSessionAllowed { get; set; }
        public int MaxGuestsPerAttendee { get; set; }
        public DateTime? DefaultCheckInDate { get; set; }
        public DateTime? DefaultCheckOutDate { get; set; }
        public string EligibleGroup { get; set; }
        public int EventTypeId { get; set; }       
        public DateTime? ConfirmationDate { get; set; }
        public string DetailsHtml { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string UrlName { get; set; }
        public string GMSListCode { get; set; }
        public virtual string LocationName { get; set; }
        public virtual string EventTypeName { get; set; }
        public bool Active { get; set; }

    }
}
