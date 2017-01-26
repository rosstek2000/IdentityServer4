using AutoMapper;
using EventManager.Core;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EventManager.Controllers.Api
{
   
    public class LocationsController : ApiController
    {
        private IEventManagerRepository _repository;
     
        public LocationsController()
        {
            _repository = new EventManagerRepository();
            
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/locations/{id}")]
        [HttpGet()]
        public List<LocationViewModel> Get(int id)
        {

            return _repository.GetAllLocations();
        }

        //[HttpGet()]
        //public JsonResult Get(int id)
        //{

        //    var returnLocation = _repository.GetLocationById(id);
        //    if (returnLocation.Count > 0)
        //        return Json(returnLocation);
        //    else
        //    {
        //        LocationViewModel e = new LocationViewModel();
        //        List<LocationViewModel> locationViewModel = new List<LocationViewModel>();
        //        locationViewModel.Add(e);
        //        return Json(locationViewModel);
        //    }
        //}

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/locations/update")]
        [HttpGet()]
        [HttpPost()]
        public Location update([FromBody]LocationViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<LocationViewModel, Location>());
                    var mapper = config.CreateMapper();

                    Location newLocation = mapper.Map<Location>(vm);
                    return _repository.AddLocation(newLocation);
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
