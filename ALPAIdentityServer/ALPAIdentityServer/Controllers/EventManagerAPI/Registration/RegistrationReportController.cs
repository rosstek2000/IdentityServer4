using EventManager.Core;
using EventManager.ViewModels;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EventManager.Controllers.Api
{
    public class RegistrationReportController : ApiController
    {
        private IEventManagerRepository _repository;

        public RegistrationReportController()
        {
            _repository = new EventManagerRepository();
        }

        [Route("api/GetReportDataByAttendeeEventId/{attendeeId}/{eventId}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<AttendeeRegistrationViewModel> Get(int attendeeId, int eventId)
        {
            return _repository.GetReportDataByAttendeeEventId(attendeeId, eventId);
        }
    }
}


