using AutoMapper;
using EventManager.Core;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EventManager.Controllers.Api
{
   
    public class RegistrationProcessScreenQuestionsController : ApiController
    {


        private IEventManagerRepository _repository;
               
        public RegistrationProcessScreenQuestionsController()
        {
            _repository = new EventManagerRepository();
        }

        [Route("api/RegistrationProcessScreenQuestions/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<RegistrationProcessScreenQuestionsViewModel> Get(int id)
        {
            return _repository.GetRegistrationProcessScreenQuestions(id);
        }

        [HttpPost()]
        [Route("api/RegistrationProcessScreenQuestions/delete/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public void Delete(int id)
        {

           try
            {
                if (ModelState.IsValid)
                {
                    _repository.DeleteRegistrationProcessScreenQuestion(id);
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        [Route("api/RegistrationProcessScreenQuestions/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost()]
        public RegistrationProcessScreenQuestion update([FromBody]RegistrationProcessScreenQuestionsViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<RegistrationProcessScreenQuestionsViewModel, RegistrationProcessScreenQuestion>());
                    var mapper = config.CreateMapper();

                    RegistrationProcessScreenQuestion newRegistrationProcessScreenQuestion = mapper.Map<RegistrationProcessScreenQuestion>(vm);
                    _repository.AddRegistrationProcessScreenQuestion(newRegistrationProcessScreenQuestion);

                    return newRegistrationProcessScreenQuestion;
                }

                return null;
            } 
            catch (Exception)
            { 
                return null;
            }

        }


    }
}
