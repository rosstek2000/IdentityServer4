using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table ("RegistrationProcessScreenQuestion")]
    public class RegistrationProcessScreenQuestion
    {
        public int Id { get; set; }
        public int RegistrationProcessId { get; set; }
        public int RegistrationScreenQuestionId { get; set; }
        public int DisplayOrder { get; set; }
       

    }
}

