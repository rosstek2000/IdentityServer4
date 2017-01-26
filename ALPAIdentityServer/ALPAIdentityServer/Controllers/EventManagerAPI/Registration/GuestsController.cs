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
    public class GuestsController: ApiController
    {
        private IEventManagerRepository _repository;

        public GuestsController()
        {
            _repository = new EventManagerRepository();
        }


        [Route("api/guestsbyAttendeeId/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<GuestViewModel> Get(int id )
        {
            return _repository.GetGuestsByAttendeeId(id);
        }

        [Route("api/guestsbyAttendeeId/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost()]
        public Guest update(GuestViewModel vm)
        {
          
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<GuestViewModel, Guest>());
                    var mapper = config.CreateMapper();
                    Guest newGuest = mapper.Map<Guest>(vm);
                    _repository.AddGuest(newGuest);

                    if (_repository.SaveAll())
                    {
                        ModelState.Clear();
                        return newGuest;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [Route("api/guestsbyAttendeeId/delete")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost()]
        public void delete(GuestViewModel vm)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<GuestViewModel, Guest>());
                    var mapper = config.CreateMapper();
                    Guest newGuest = mapper.Map<Guest>(vm);
                    _repository.DeleteGuest(newGuest);

                    if (_repository.SaveAll())
                    {
                        ModelState.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
            return;
        }
    }
}