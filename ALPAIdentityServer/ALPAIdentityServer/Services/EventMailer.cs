using Mvc.Mailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventManager.Core;
using System.Configuration;
using EventManager.ViewModels;

namespace ALPAIdentityServer.Services
{
    
    public class EventMailer : MailerBase, IEventMailer
    {
        public EventMailer()
        {
            MasterName = "_Layout";
        }


       
        public virtual MvcMailMessage Registration(AttendeeViewModel attendee, List<GuestViewModel> guests, List<AttendeeRegistrationViewModel> registrations, EventViewModel events)
        {
            ViewBag.attendee = attendee;
            ViewBag.guests = guests;
            ViewBag.registrations = registrations;
            ViewBag.events = events;

            return Populate(x =>
            {
                x.Subject = string.Format("Registration Submitted: {0}", attendee.FirstName + ' ' + attendee.LastName);
                x.ViewName = "Registration";
                var emailAddress = ConfigurationManager.AppSettings["RegistrationEmail"];
                if (!string.IsNullOrWhiteSpace(emailAddress))
                {
                    x.To.Add(emailAddress);
                    x.To.Add("Nancy.Halsey@alpa.org");
                    x.To.Add("Cookie.Robinson@alpa.org");
                }
            });
        }
    }
}