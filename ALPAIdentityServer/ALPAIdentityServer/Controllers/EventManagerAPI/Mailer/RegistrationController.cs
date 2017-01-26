using EventManager.Core;
using EventManager.ViewModels;
using ALPAIdentityServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EventManager.Controllers.Api
{
    public class RegistrationController : ApiController
    {

        private IEventManagerRepository _repository;
        private IEventMailer _eventMailer = new EventMailer();


        public RegistrationController()
        {
            _repository = new EventManagerRepository();
        }
        [Route("api/mailRegistrationInfo/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost()]
        public HttpResponseMessage Post(int id)
        {
            List<AttendeeViewModel> attendee = _repository.GetAttendeeById(id);
            List<GuestViewModel> guests = _repository.GetGuestsByAttendeeId(id);
            
            List<AttendeeRegistrationViewModel> registrations = _repository.GetReportDataByAttendeeEventId(id, attendee[0].EventId);

            List<EventViewModel> events = _repository.GetEventById(attendee[0].EventId);

            _eventMailer.Registration(attendee[0], guests, registrations, events[0]).Send();
            return Request.CreateResponse(HttpStatusCode.Created);
        }

    }
}