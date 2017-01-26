using EventManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.ViewModels
{
    public class RegistrationQuestionTypesViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public int RegistrationQuestionFormatId { get; set; }

    }
}
