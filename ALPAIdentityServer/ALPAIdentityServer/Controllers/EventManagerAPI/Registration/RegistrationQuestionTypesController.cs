using AutoMapper;
using EventManager.Core;
using EventManager.ViewModels;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EventManager.Controllers.Api
{
    [Route("api/registrationquestiontypes")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegistrationQuestionTypesController : ApiController
    {

        private IEventManagerRepository _repository;
             
        public RegistrationQuestionTypesController()
        {
            _repository = new EventManagerRepository();
        }

        [HttpGet()]
        public List<RegistrationQuestionTypesViewModel> Get()
        {
            return _repository.GetRegistrationQuestionTypes(); 
        }
    }
}
