using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    public partial class SessionFee
    {
        public int Id { get; set; }
        public int AttendeeTypeId { get; set; }
        public decimal Fee { get; set; }
        public int SessionId { get; set; }

      
    }
}
