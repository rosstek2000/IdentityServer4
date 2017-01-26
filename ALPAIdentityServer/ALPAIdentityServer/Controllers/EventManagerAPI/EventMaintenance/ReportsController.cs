using EventManager.Core;
using EventManager.ViewModels;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManager.Controllers.Api
{
   
    public class ReportsController : ApiController
    {
        private IEventManagerRepository _repository;

        public ReportsController()
        {
            _repository = new EventManagerRepository();

        }

        [HttpGet()]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/reports/rptAttendeeBadge/{eventId}")]
        public List<rptAttendeeBadgeViewModel> Get(int eventId)
        {
            return _repository.GetrptAttendeeBadge(eventId);
        }


    }
}
