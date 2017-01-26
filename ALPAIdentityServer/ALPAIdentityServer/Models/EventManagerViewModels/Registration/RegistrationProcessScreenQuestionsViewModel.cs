using EventManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.ViewModels
{
    public class RegistrationProcessScreenQuestionsViewModel
    {

        public int Id { get; set; }
        public int RegistrationProcessId { get; set; }
        public int RegistrationScreenQuestionId { get; set; }
        public int DisplayOrder { get; set; }
        public string QuestionVerbiage { get; set; }
        public string SelectOptions { get; set; }
        public RegistrationScreenQuestion RegistrationConditionalQuestionName { get; set; }

    }
}
