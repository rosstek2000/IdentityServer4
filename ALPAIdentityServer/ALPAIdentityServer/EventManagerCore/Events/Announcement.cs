using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("Announcements")]
    public partial class Announcement
    {

        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public RegistrationProcess RegistrationProcess { get; set; }

    }
}
