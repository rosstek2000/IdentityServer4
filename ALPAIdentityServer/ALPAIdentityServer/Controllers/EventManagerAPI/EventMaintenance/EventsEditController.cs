
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
    
    public class EventsEditController: ApiController
    {
        private IEventManagerRepository _repository;
     
        public EventsEditController()
        {
            _repository = new EventManagerRepository();
        }

        [Route("api/editEvent/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<EventViewModel> Get(int id)
        {
           return _repository.GetEventById(id);
        }


        [HttpPost()]
        [Route("api/editEvent/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Event Update(EventViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<EventViewModel, Event>());
                    var mapper = config.CreateMapper();

                    Event newEvent = mapper.Map<Event>(vm);
                    
                    _repository.AddEvent(newEvent);

                    if (_repository.SaveAll())
                    {
                        ModelState.Clear();
                        return newEvent;
                    }
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
