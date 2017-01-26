using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManager.ViewModels
{
   
    public class RegistrationQuestionExternalMappingViewModel
    {
        public int Id { get; set; }
        public int RegistrationProcessScreenQuestionId  { get; set; }
        public string AttendeeColumnMapping { get; set; }

    }
}