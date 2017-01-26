using AutoMapper;
using EventManager.Core;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EventManager.Controllers.Api
{
    
    public class RegistrationScreenQuestionsByEventController : ApiController
    {

        private IEventManagerRepository _repository;
              
        public RegistrationScreenQuestionsByEventController()
        {
            _repository = new EventManagerRepository();
        }

        [Route("api/registrationscreenquestionsbyevent/{eventId}/{screenId}/{attendeeId}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<RegistrationScreenQuestionViewModel> Get(int eventId, int screenId, int attendeeId)
        {
            return _repository.GetRegistrationScreenQuestionsByEventId(eventId, screenId, attendeeId);
        }


        [HttpPost()]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Post([FromBody]RegistrationScreenQuestionViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RegistrationScreenQuestion newRegistrationScreenQuestion = Mapper.Map<RegistrationScreenQuestion>(vm);
                  
                   _repository.AddRegistrationScreenQuestion(newRegistrationScreenQuestion);

                    if (_repository.SaveAll())
                    {
                        ModelState.Clear();
                        return "Registration Screen Question Created Successfully";
                    }
                }

                return "Registration Screen Question Created Failed";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
