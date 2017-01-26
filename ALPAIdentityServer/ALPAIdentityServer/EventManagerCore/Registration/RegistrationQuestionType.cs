using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("RegistrationQuestionTypes")]
    public partial class RegistrationQuestionType
    {
      

        public int Id { get; set; }
        public bool Active { get; set; }
        public int QuestionId { get; set; }
       
        [MaxLength(250)]
        public string Name { get; set; }
        public int RegistrationQuestionFormatId { get; set; }

        RegistrationQuestionFormat RegistrationQuestionFormat { get; set; }
    }
}
