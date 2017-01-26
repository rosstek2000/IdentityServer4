using EventManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.ViewModels
{
    public class RegistrationProcessViewModel
    {
        public int Id { get; set; }
        [Required]
        public int EventId { get; set; }
        public int RegistrationScreenId { get; set; }
        public int ScreenOrder { get; set; }
        public bool AdditionalQuestions { get; set; }
        public string ScreenName { get; set; }
        public bool RequiredScreen { get; set; }
        public string TemplateUrl { get; set; }
        

    }
}
