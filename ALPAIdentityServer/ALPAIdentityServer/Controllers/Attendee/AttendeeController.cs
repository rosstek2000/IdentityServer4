using AutoMapper;
using EventManager.Core;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ALPAIdentityServer.Controllers.Api
{
    public class AttendeeController : ApiController
    {
        private IEventManagerRepository _repository;


        public AttendeeController()
        {
            _repository = new EventManagerRepository();
        }

        [Route("api/attendee/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<AttendeeViewModel> Get(int id)
        {
            return _repository.GetAttendeeById(id);
        }

        [HttpPost()]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/attendee/updateRegistrationbyId/{id}")]
        public void updateRegistrationbyId(int id)
        {
            List<AttendeeViewModel> vm = Get(id);
            vm[0].RegisterComplete = true;
            vm[0].RegisterCompleteDate = System.DateTime.Now;
            Update(vm[0]);

        }

        [Route("api/attendee/GetByAlpaId/{id}/{eventId}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<AttendeeViewModel> GetByAlpaId(string id, int eventId)
        {
            return _repository.GetAttendeeByAlpaId(id, eventId);
        }

        [HttpPost()]
        [Route("api/attendee/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Attendee Update(AttendeeViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<AttendeeViewModel, Attendee>());
                    var mapper = config.CreateMapper();

                    Attendee newAttendee = mapper.Map<Attendee>(vm);                    
                    newAttendee = _repository.AddAttendee(newAttendee);
                    newAttendee.Guests = vm.Guests;

                    ModelState.Clear();
                    return newAttendee;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}