
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using ALPAIdentityServer.Models;
using EventManager.Core;
using EventManager.ViewModels;
using System.Web.Http.Cors;

namespace EventManager.Controllers.Api
{

    
    
    public class EventsController : ApiController
    {
        IEventManagerRepository _context;
        public EventsController()
        {
            _context = new EventManagerRepository();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/events")]
        public List<EventViewModel> Get()
        {

           return _context.GetAllEvents();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        [Route("api/events/active")]
        public List<EventViewModel> GetActiveEvents()
        {
            return _context.GetAllActiveEvents();
        }
    }
}
