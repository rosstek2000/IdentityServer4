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
    public class DashboardController: ApiController
    {
        private IEventManagerRepository _repository;

        public DashboardController()
        {
            _repository = new EventManagerRepository();
        }


        [Route("api/GetDashboardCurrentRegistrations/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<DashboardCurrentRegistrationsViewModel> Get(int id )
        {
            return _repository.GetDashboardCurrentRegistrations(id);
        }



        [Route("api/GetDashboardNotRegistered/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<DashboardCurrentRegistrationsViewModel> GetDashboardNotRegistered(int id)
        {
            return _repository.GetDashboardNotRegistered(id);
        }


        [Route("api/GetDashboardNotAttending/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet()]
        public List<DashboardCurrentRegistrationsViewModel> GetDashboardNotAttending(int id)
        {
            return _repository.GetDashboardNotAttending(id); ;
        }

    }
}