using AutoMapper;
using EventManager.Core;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EventManager.Controllers.Api
{
    [Route("api/registrationprocesses/{id}")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegistrationProcessController : ApiController
    {


        private IEventManagerRepository _repository;
     
        public RegistrationProcessController()
        {
            _repository = new EventManagerRepository();

        }

        [Route("api/registrationprocesses/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<RegistrationProcessViewModel> Get(int id)
        {

            return _repository.GetRegistrationProcessById(id);

        }

        [Route("api/registrationprocesses/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost()]
        public RegistrationProcess update ([FromBody]RegistrationProcessViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<RegistrationProcessViewModel, RegistrationProcess>());
                    var mapper = config.CreateMapper();

                    RegistrationProcess newRegistrationProcess = mapper.Map<RegistrationProcess>(vm);

                    
                    return _repository.AddRegistrationProcess(newRegistrationProcess);

                  
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [Route("api/registrationprocesses/delete")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost()]
        public string delete([FromBody]int id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _repository.DeleteRegistrationProcess(id);
                    return "Deleted Registration Process successfully";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Deleted Registration Process failed";

        }

        }
}
