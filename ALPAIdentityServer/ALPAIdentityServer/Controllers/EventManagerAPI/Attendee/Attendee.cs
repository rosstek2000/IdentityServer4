using AutoMapper;
using EventManager.Core;
using EventManager.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace EventManager.Controllers.Api
{
    [Route("api/register/{id}")]
    public class AttendeeRegister : Controller
    {


        private IEventManagerRepository _repository;
        private IMapper _mapper;
        private ILogger<RegistrationScreensController> _logger;


        public AttendeeRegister(IEventManagerRepository repository, ILogger<RegistrationScreensController> logger)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RegistrationScreensViewModel, RegistrationScreen>());
            var mapper = config.CreateMapper();

            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get(int id)
        {

            return null;
        }
        
    }
}
