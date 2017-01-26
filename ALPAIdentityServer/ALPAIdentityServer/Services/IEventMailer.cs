using EventManager.Core;
using EventManager.ViewModels;
using Mvc.Mailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALPAIdentityServer.Services
{
    public interface IEventMailer
    {

        MvcMailMessage Registration(AttendeeViewModel attendee, List<GuestViewModel> guests, List<AttendeeRegistrationViewModel> registrations, EventViewModel events);
    }
}