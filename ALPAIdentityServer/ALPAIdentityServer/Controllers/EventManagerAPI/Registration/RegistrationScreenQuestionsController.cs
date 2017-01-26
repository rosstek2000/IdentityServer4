using AutoMapper;
using EventManager.Core;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;


namespace EventManager.Controllers.Api
{
    
    public class RegistrationScreenQuestionsController : ApiController
    { 

        private IEventManagerRepository _repository;
              
        public RegistrationScreenQuestionsController()
        {
            _repository = new EventManagerRepository();
        }

        [Route("api/registrationscreenquestions/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<RegistrationScreenQuestionViewModel> Get(int id)
        {
            if (id > 0)
                return _repository.GetRegistrationScreenQuestions(id);
            else
                return _repository.GetAllRegistrationScreenQuestions();
        }



        [Route("api/registrationscreenquestions/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        [HttpPost()]
        public RegistrationScreenQuestion update(RegistrationScreenQuestionViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<RegistrationScreenQuestionViewModel, RegistrationScreenQuestion>());
                    var mapper = config.CreateMapper();

                    RegistrationScreenQuestion newRegistrationScreenQuestion = mapper.Map<RegistrationScreenQuestion>(vm);
    
                   _repository.AddRegistrationScreenQuestion(newRegistrationScreenQuestion);

                    if (_repository.SaveAll())
                    {
                        ModelState.Clear();

                        return newRegistrationScreenQuestion;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                 return null;
            }
        }   


    }
}
