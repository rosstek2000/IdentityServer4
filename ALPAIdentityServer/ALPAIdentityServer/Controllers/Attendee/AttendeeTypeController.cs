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
    public class AttendeeTypeController : ApiController
    {
        private IEventManagerRepository _repository;


        public AttendeeTypeController()
        {
            _repository = new EventManagerRepository();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/attendeeTypes")]
        [HttpGet()]
        public List<AttendeeTypeViewModel> Get()
        {
            return _repository.GetAttendeeTypes();
        }

      
    }
}