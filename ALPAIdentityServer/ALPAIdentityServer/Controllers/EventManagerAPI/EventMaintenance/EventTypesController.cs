using AutoMapper;
using EventManager.Core;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManager.Controllers.Api
{
    [Route("api/eventtypes/")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EventTypesController: ApiController
    {
        private IEventManagerRepository _repository;
     

        public EventTypesController()
        {

            _repository = new EventManagerRepository();
        }

        [Route("api/eventtypes/")]
        [HttpGet]
        public IEnumerable<EventTypeViewModel> GetAllEventTypes()
        {
            return _repository.GetAllEventTypes();
        }

        [Route("api/eventtypes/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public EventType update([FromBody]EventTypeViewModel vm)

        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventTypeViewModel, EventType>());
            var mapper = config.CreateMapper();

            EventType newEventType = mapper.Map<EventType>(vm);
            try
            {
                if (ModelState.IsValid)
                {
                    return _repository.AddEventType(newEventType);    
                 
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }


    }
}
