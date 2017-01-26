using AutoMapper;
using EventManager.Core;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EventManager.Controllers.Api
{
    public class EventManagerSessionController: ApiController
    {
        private IEventManagerRepository _repository;


        public EventManagerSessionController()
        {
            _repository = new EventManagerRepository();
        }

        [Route("api/EventManagerSession/{sessionGuid}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public EventManagerSessionViewModel Get(string sessionGuid)
        {
            return _repository.GetEventManagerSessionBySessionGuid(sessionGuid);
        }

        [HttpPost()]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/EventManagerSession/update")]
        public EventManagerSession Update(EventManagerSessionViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<EventManagerSessionViewModel, EventManagerSession>());
                    var mapper = config.CreateMapper();

                    EventManagerSession newEventManagerSession = mapper.Map<EventManagerSession>(vm);

                    _repository.AddEventManagerSession(newEventManagerSession);

                  
                    ModelState.Clear();
                    return newEventManagerSession;
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