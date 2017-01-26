using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("RegistrationScreens")]
    public partial class RegistrationScreen
    {
        public int Id { get; set; }
        public bool? Active { get; set; }
        public int? DefaultOrder { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string TemplateUrl { get; set; }
        public bool RequiredScreen { get; set; }
        public virtual ICollection<RegistrationScreenQuestion> RegistrationScreenQuestion { get; set; }

    }
}
