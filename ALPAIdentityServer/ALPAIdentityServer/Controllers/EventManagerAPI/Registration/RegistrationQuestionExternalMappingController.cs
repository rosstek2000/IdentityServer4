using EventManager.Core;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ALPAIdentityServer.Controllers.EventManagerAPI.Registration
{
    public class RegistrationQuestionExternalMappingController : ApiController
    {
        private IEventManagerRepository _repository;

        public RegistrationQuestionExternalMappingController()
        {
            _repository = new EventManagerRepository();
        }

        [Route("api/RegistrationQuestionExternalMappings")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<RegistrationQuestionExternalMappingViewModel> Get()
        {
            var returnEvent = _repository.GetRegistrationQuestionExternalMappings();
            if (returnEvent.Count > 0)
                return returnEvent;
            else
            {
                return null;
            }
        }
    }
}