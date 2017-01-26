using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("RegistrationQuestionFormats")]
    public partial class RegistrationQuestionFormat
    {

        public int Id { get; set; }
        public bool Active { get; set; }
        public string Format { get; set; }
        public string Name { get; set; }

      
    }
}
