using EventManager.Core;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EventManager.Controllers.Api
{
    [Route("api/registrationscreens")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class RegistrationScreensController : ApiController
    {
        private IEventManagerRepository _repository;
        
        public RegistrationScreensController()
        {
            _repository = new EventManagerRepository();
        }

        [HttpGet()]
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public List<RegistrationScreensViewModel> Get()
        {
            var returnEvent = _repository.GetRegistrationScreensAll();
            if (returnEvent.Count > 0)
                return returnEvent;
            else
            {
                return null;
            }
        }

        [HttpDelete]
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public void Delete(int id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _repository.DeleteRegistrationScreen(id);
                    return;
                }
            }
            catch (Exception)
            {
               
            }


        }


    }
}
