using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table ("RegistrationProcesses")]
    public class RegistrationProcess
    { 
        public int Id { get; set; }
        public int EventId { get; set; }
        public int RegistrationScreenId { get; set; }
        public int ScreenOrder { get; set; }
      
    }
}
