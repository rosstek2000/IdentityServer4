using EventManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.ViewModels
{
    public class RegistrationScreensViewModel
    {
        public int Id { get; set; }
        public bool? Active { get; set; }
        public int? DefaultOrder { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string TemplateUrl { get; set; }
        public bool RequiredScreen { get; set; }

    }
}
