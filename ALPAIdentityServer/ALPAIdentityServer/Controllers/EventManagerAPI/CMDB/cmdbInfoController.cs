using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using EventManager.Core;
using EventManager.ViewModels;
using System.Web.Http.Cors;

namespace EventManager.Controllers.Api
{
    public class cmdbInfoController: ApiController
    {
        EventManagerRepository _context;
        public cmdbInfoController()
        {
            _context = new EventManagerRepository();
        }


        [HttpGet()]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/memberData/{alpaId}/{eventId}")]
        public List<GMSMemberDataViewModel> Get(string alpaID, int eventId)
        {
            return _context.GetMemberDataUsingAlpaId(alpaID, eventId);
        }



       
    }
}