using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManager.Core
{
    [Table("EventManagerSessions")]
    public class EventManagerSession
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int AttendeeId { get; set; }
        public int EventId { get; set; }
        public string AttendeeUserName { get; set; }
        public string SessionGuid { get; set; }
        public DateTime Login  { get; set; }
    }
}