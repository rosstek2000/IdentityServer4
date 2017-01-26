using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManager.Core
{
    [Table("RegistrationQuestionExternalMappings")]
    public class RegistrationQuestionExternalMapping
    {
        public int Id { get; set; }
        public int RegistrationProcessScreenQuestionId { get; set; }
        public string AttendeeColumnMapping { get; set; }

    }
}