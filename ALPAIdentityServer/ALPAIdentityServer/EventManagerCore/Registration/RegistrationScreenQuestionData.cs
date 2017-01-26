using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("RegistrationScreenQuestionData")]
    public partial class RegistrationScreenQuestionData
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public DateTime? DateAnswered { get; set; }
        public int RegistrationProcessScreenQuestionId { get; set; }
        public int AttendeeId { get; set; }
        public int EventId { get; set; }
    }
}
