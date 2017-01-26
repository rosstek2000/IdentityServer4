using ALPAIdentityServer.Controllers.AIROAPI;
using ALPAIdentityServer.Models.AIROViewModels;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AIRO.Controllers.Api
{
    public class PersonController : ApiController
    {
        private IAERORepository _context;


        public PersonController()
        {
            _context = new AERORepository();
        }

      
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/personDataAIRO/{id}")]
        public List<PersonViewModel> Get(int id)
        {
            return _context.GetPerson(id);
        }

        [Authorize]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/personDataAIROUsingView/{id}")]
        public List<PersonViewModel> GetUsingView(int id)
        {
            return _context.GetPersonUsingView(id);
        }

        
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/personDataAIROByAlpaId/{id}")]
        public List<PersonViewModel> GetPersonByAlpaId(string id)
        {
            return _context.GetPersonByAlpaId(id);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/personDataAIROByLastName/{id}")]
        public List<PersonViewModel> GetPersonByLastName(string id)
        {
            return _context.GetPersonByLastName(id);
        }

    }
}


