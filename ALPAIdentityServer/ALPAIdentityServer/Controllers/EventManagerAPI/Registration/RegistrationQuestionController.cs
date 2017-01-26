using EventManager.Core;
using EventManager.ViewModels;
using System;
using System.Net;
using System.Web.Http;
using AutoMapper;
using System.Web.Http.Cors;

namespace EventManager.Controllers.Api
{
    [Route("api/registrationquestion/{id}")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegistrationQuestionController : ApiController
    {
        private IEventManagerRepository _repository;
        
        public RegistrationQuestionController()
        {
            _repository = new EventManagerRepository();
        }

        [HttpGet()]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public RegistrationScreenQuestionViewModel Get(int id)
        {

            return _repository.GetRegistrationQuestionById(id); 
           
        }

        [HttpPost()]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Post([FromBody]RegistrationScreenQuestionViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RegistrationScreenQuestion newRegistrationQuestion = Mapper.Map<RegistrationScreenQuestion>(vm);
                    if (newRegistrationQuestion.Id == 0)
                        return null;
                    _repository.AddRegistrationScreenQuestion(newRegistrationQuestion);


                    if (_repository.SaveAll())
                    {
                        ModelState.Clear();
                        return "Registration Screen Added Successfully";
                    }
                }

                return "Registration Screen Added Failed";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
