using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManager.ViewModels
{
    public class RegistrationProcessScreenQuestionDataViewModel
    {
            public int Id { get; set; }
            public string Value { get; set; }
            public DateTime? DateAnswered { get; set; }
            public int RegistrationProcessScreenQuestionId  { get; set; }
            public int AttendeeId { get; set; }
            public int EventId { get; set; }
     
    }
}