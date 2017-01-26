using AutoMapper;
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
    public class RegistrationScreenQuestionDataController: ApiController
    {
        private IEventManagerRepository _repository;

        public RegistrationScreenQuestionDataController()
        {
            _repository = new EventManagerRepository();
        }

        [Route("api/RegistrationScreenQuestionData/{attendeeId}/{eventId}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<RegistrationScreenQuestionDataViewModel> Get(int attendeeId, int eventId)
        {
            return _repository.GetRegistrationScreenQuestionData(attendeeId, eventId);
        }

        [HttpPost()]
        [Route("api/RegistrationScreenQuestionData/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public RegistrationScreenQuestionData[] Update(RegistrationScreenQuestionData[] vm)
        {
            foreach(RegistrationScreenQuestionData registrationScreenQuestionData in vm)
            {
                var registrationScreenQuestionDataViewModel = _repository.GetRegistrationQuestionScreenData(registrationScreenQuestionData.AttendeeId, registrationScreenQuestionData.EventId, registrationScreenQuestionData.RegistrationProcessScreenQuestionId);
                if (registrationScreenQuestionDataViewModel != null)
                {
                    // _repository.DeleteRegistrationScreenQuestionData(registrationScreenQuestion);
                    registrationScreenQuestionData.Id = registrationScreenQuestionDataViewModel.Id;
                }
                try
                {
                    if (ModelState.IsValid)
                    {
                        _repository.AddRegistrationQuestionScreenData(registrationScreenQuestionData);
                        ModelState.Clear();
                    }                    
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return vm;
        }
    }
}