using EventManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.ViewModels
{
    public class RegistrationScreenQuestionViewModel
    {
        public int Id { get; set; }
        public int RegistrationQuestionTypeId { get; set; }
        public string QuestionVerbiage { get; set; }
        public string HelpText { get; set; }
        public int? ConditionalQuestionId { get; set; }
        public int? RegistrationScreenId { get; set; }
        public string ReportDataName { get; set; }
        public bool RequiredQuestion { get; set; }
        public string RequiredText { get; set; }
        public string SelectOptions { get; set; }
        public string SelectOptionsDefault { get; set; }
        public string QuestionDescription { get; set; }
        public string RegistrationQuestionTypeName { get; set; }
        public string RegistrationScreenName { get; set; }
        public bool CMDBSource { get; set; }
        public bool ExternalSource { get; set; }
        public bool SystemGenerated { get; set; }
        public bool Active { get; set; }
        public string Answer { get; set; }
        public bool DefaultQuestion { get; set; }
        public int RegistrationProcessScreenQuestionId { get; set; }

        public string ConditionalQuestionResponse{ get; set; }
    public RegistrationScreenQuestion RegistrationConditionalQuestionName { get; set; }


    }
}
