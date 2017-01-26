using AutoMapper;
using EventManager.ViewModels;
using ALPAIdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EventManager.Core
{
     public class EventManagerRepository : IEventManagerRepository
        {
            private ApplicationDbContext _context;
           
        public EventManagerRepository()
            {
                _context = ApplicationDbContext.Create();
            }

        #region Get Methods

        /// <summary>
        /// Returns List of Data elements from answers from registration used in the email sent to user by attendeeId and EventId
        /// </summary>
       
        public List<AttendeeRegistrationViewModel> GetReportDataByAttendeeEventId(int attendeeId, int eventId)
        {
            var Queryablemodel = (from x in _context.Attendees.Where(e=> e.Id == attendeeId)
                                  join y in _context.Events on x.EventId equals y.Id
                                  join z in _context.RegistrationScreenQuestionData on y.Id equals z.EventId 
                                  join b in _context.RegistrationProcessScreenQuestions on z.RegistrationProcessScreenQuestionId equals b.Id
                                  join a in _context.RegistrationScreenQuestions on b.RegistrationScreenQuestionId equals a.Id
                                    
                                  select new AttendeeRegistrationViewModel
                                  {
                                      AttendeeId = z.AttendeeId,
                                      ReportDataName = a.ReportDataName,
                                      Value = z.Value,
                                      RequiredQuestion = a.RequiredQuestion,
                                      RegisterCompleteDate = x.RegisterCompleteDate,
                                      RegisterComplete = x.RegisterComplete,
                                      EventStartDate = y.StartDate,
                                      EventEndDate = y.EndDate,
                                      EventName = y.Name,
                                      EventId = y.Id,
                                      RequiredText = a.RequiredText
                                }).Where(c => c.AttendeeId == attendeeId && c.EventId == eventId).AsQueryable().ToList<AttendeeRegistrationViewModel>()
                                    ;
            
            return Queryablemodel;
        }
        public List<GuestViewModel> GetGuestsByAttendeeId(int id)
        {
            var Queryablemodel = (from x in _context.Guests
                                  select new
                                  GuestViewModel
                                  {
                                      Id = x.Id,
                                      AttendeeId = x.AttendeeId,
                                      FirstName = x.FirstName,
                                      LastName = x.LastName,
                                      Comments = x.Comments,
                                      BadgeId = x.BadgeId,
                                      Attended = x.Attended

                                  }).Where(y => y.AttendeeId == id).AsQueryable().ToList<GuestViewModel>();
            return Queryablemodel;
        }

        public List<AttendeeTypeViewModel> GetAttendeeTypes()
        {
            var Queryablemodel = (from x in _context.AttendeeTypes
                                  select new
                                  AttendeeTypeViewModel
                                  {
                                      Id = x.Id,
                                      Name = x.Name

                                  }).AsQueryable().ToList<AttendeeTypeViewModel>();
            return Queryablemodel;
        }

        public RegistrationScreenQuestionDataViewModel GetRegistrationQuestionScreenData(int attendeeId, int eventId, int questionId)
        {
            var rc = (from x in _context.RegistrationScreenQuestionData
                                  select new
                                  RegistrationScreenQuestionDataViewModel
                                  {
                                      Id = x.Id,
                                      AttendeeId = x.AttendeeId,
                                      DateAnswered = x.DateAnswered,
                                      RegistrationProcessScreenQuestionId = x.RegistrationProcessScreenQuestionId,
                                      Value = x.Value,
                                      EventId = x.EventId
                                  }).Where(y => y.EventId == eventId).Where(z => z.AttendeeId == attendeeId)
                                    .Where(zz=> zz.RegistrationProcessScreenQuestionId == questionId).AsQueryable().Any<RegistrationScreenQuestionDataViewModel>();
            if (rc)
                return (from x in _context.RegistrationScreenQuestionData
                 select new
                 RegistrationScreenQuestionDataViewModel
                 {
                     Id = x.Id,
                     AttendeeId = x.AttendeeId,
                     DateAnswered = x.DateAnswered,
                     RegistrationProcessScreenQuestionId = x.RegistrationProcessScreenQuestionId,
                     Value = x.Value,
                     EventId = x.EventId
                 }).Where(y => y.EventId == eventId).Where(z => z.AttendeeId == attendeeId)
                                    .Where(z => z.RegistrationProcessScreenQuestionId == questionId).AsQueryable().First<RegistrationScreenQuestionDataViewModel>();
            else

                return null; 
        }

        public List<RegistrationScreenQuestionDataViewModel> GetRegistrationScreenQuestionData(int attendeeId, int eventId)
        {

            var Queryablemodel = (from x in _context.RegistrationScreenQuestionData
                                  select new
                                  RegistrationScreenQuestionDataViewModel
                                  {
                                      Id = x.Id,
                                      AttendeeId = x.AttendeeId,
                                      DateAnswered = x.DateAnswered,
                                      RegistrationProcessScreenQuestionId = x.RegistrationProcessScreenQuestionId,
                                      Value = x.Value,
                                      EventId = x.EventId
                                  }).Where(y => y.EventId == eventId).Where(z=>z.AttendeeId == attendeeId).AsQueryable().ToList<RegistrationScreenQuestionDataViewModel>();
            return Queryablemodel;
        }

        public List<RegistrationQuestionExternalMappingViewModel> GetRegistrationQuestionExternalMappings()
        {
            var Queryablemodel = (from x in _context.RegistrationQuestionExternalMappings
                                  select new
                                  RegistrationQuestionExternalMappingViewModel
                                  {
                                      Id = x.Id,
                                      RegistrationProcessScreenQuestionId = x.RegistrationProcessScreenQuestionId,
                                      AttendeeColumnMapping = x.AttendeeColumnMapping

                                  }).AsQueryable().ToList<RegistrationQuestionExternalMappingViewModel>();
            return Queryablemodel;
        }

        public List<AttendeeViewModel> GetAttendeeByAlpaId(string id, int eventId)
        {
            try
            {
                var Queryablemodel = (from x in _context.Attendees
                                      select new
                                      AttendeeViewModel
                                      {
                                          Id = x.Id,
                                          ALPANumber = x.ALPANumber,
                                          AttendeeTypeId = x.AttendeeTypeId,
                                          FirstName = x.FirstName,
                                          LastName = x.LastName,
                                          Organization = x.Organization,
                                          RepPosition = x.RepPosition,
                                          Council = x.Council,
                                          EventId = x.EventId,
                                          BadgeId = x.BadgeId,
                                          Attended = x.Attended,
                                          ProxyLogin = x.ProxyLogin,
                                          ProxyUser = x.ProxyUser,
                                          RegisterCompleteDate = x.RegisterCompleteDate,
                                          RegisterComplete = x.RegisterComplete,
                                          RegisterStarted = x.RegisterStarted

                                      }).Where(y => y.ALPANumber == id).AsQueryable().ToList<AttendeeViewModel>();
                return Queryablemodel;
            }
            catch(Exception ex)
            {
                var test = ex.Message;
                return null;
            }
        }

        public List<AttendeeViewModel> GetAttendeeById(int id)
        {
            var Queryablemodel = (from x in _context.Attendees
                                  select new
                                  AttendeeViewModel
                                  {
                                      Id = x.Id,
                                      ALPANumber = x.ALPANumber,
                                      AttendeeTypeId = x.AttendeeTypeId,
                                      FirstName = x.FirstName,
                                      LastName = x.LastName,
                                      Organization = x.Organization,
                                      EventId = x.EventId,
                                      BadgeId = x.BadgeId,
                                      Attended = x.Attended,
                                      ProxyLogin = x.ProxyLogin,
                                      ProxyUser = x.ProxyUser,
                                      RegisterCompleteDate = x.RegisterCompleteDate,
                                      RegisterComplete = x.RegisterComplete,
                                      RegisterStarted = x.RegisterStarted
                                      
                                  }).Where(y => y.Id == id).AsQueryable().ToList<AttendeeViewModel>();
            return Queryablemodel;
        }
        public List<GMSMemberDataViewModel> GetMemberDataUsingAlpaId(string alpaId, int eventId)
            {
            var Queryablemodel = (from x in _context.Member
                                  join z in _context.gmsMember on x.ALPA_ID equals z.MemberId
                                  join l in _context.gmsList on z.ListId equals l.ListId
                                  join e in _context.Events on l.ListCode equals e.GMSListCode 
                                  select new
                                  GMSMemberDataViewModel
                                  { 
                                      FRST_NAME = x.FRST_NAME,
                                      LST_NAME = x.LST_NAME,
                                      ALPA_ID = x.ALPA_ID,
                                      MEC_CD = x.MEC_CD,
                                      Memo = z.Memo,
                                      EventId = eventId,
                                      Council = x.BASE_LEC_CD,
                                      Rep_Position = x.CLASS_CD
                                  }).Where(y => y.ALPA_ID == alpaId).AsQueryable().ToList<GMSMemberDataViewModel>();
            return Queryablemodel;
          
            
        }

       
        public List<EventViewModel> GetAllEvents()
            {

                try
                {
                    var Queryablemodel = (from x in _context.Events
                                          orderby x.StartDate descending
                                          join y in _context.Locations on x.LocationId equals y.Id
                                          join z in _context.EventTypes on x.EventTypeId equals z.Id

                                          select new
                                          EventViewModel
                                          {
                                              Id = x.Id,
                                              Name = x.Name,
                                              LocationName = y.Name,
                                              EventTypeName = z.Name,
                                              StartDate = x.StartDate,
                                              EndDate = x.EndDate,
                                              MaxRegistrants = x.MaxRegistrants,
                                              RegistrationStartDate = x.RegistrationStartDate,
                                              RegistrationEndDate = x.RegistrationEndDate,
                                              IsConcurrentSessionAllowed = x.IsConcurrentSessionAllowed,
                                              MaxGuestsPerAttendee = x.MaxGuestsPerAttendee,
                                              DefaultCheckInDate = x.DefaultCheckInDate,
                                              DefaultCheckOutDate = x.DefaultCheckOutDate,
                                              EligibleGroup = x.EligibleGroup,
                                              EventTypeId = x.EventTypeId,
                                              LocationId = x.LocationId,
                                              ConfirmationDate = x.ConfirmationDate,
                                              ContactEmail = x.ContactEmail,
                                              ContactName = x.ContactName,
                                              ContactPhone = x.ContactPhone,
                                              DetailsHtml = x.DetailsHtml,
                                              UrlName = x.UrlName,
                                              GMSListCode = x.GMSListCode,
                                              Active = x.Active
                                          }).AsQueryable().ToList<EventViewModel>();

                    return Queryablemodel;


                }
                catch (Exception ex)
                {
                   
                    return null;
                }


            }
        public List<EventViewModel> GetAllActiveEvents()
            {

                try
                {
                    var Queryablemodel = (from x in _context.Events
                                          orderby x.StartDate descending
                                          join y in _context.Locations on x.LocationId equals y.Id
                                          join z in _context.EventTypes on x.EventTypeId equals z.Id

                                          select new
                                          EventViewModel
                                          {
                                              Id = x.Id,
                                              Name = x.Name,
                                              LocationName = y.Name,
                                              EventTypeName = z.Name,
                                              StartDate = x.StartDate,
                                              EndDate = x.EndDate,
                                              MaxRegistrants = x.MaxRegistrants,
                                              RegistrationStartDate = x.RegistrationStartDate,
                                              RegistrationEndDate = x.RegistrationEndDate,
                                              IsConcurrentSessionAllowed = x.IsConcurrentSessionAllowed,
                                              MaxGuestsPerAttendee = x.MaxGuestsPerAttendee,
                                              DefaultCheckInDate = x.DefaultCheckInDate,
                                              DefaultCheckOutDate = x.DefaultCheckOutDate,
                                              EligibleGroup = x.EligibleGroup,
                                              EventTypeId = x.EventTypeId,
                                              LocationId = x.LocationId,
                                              ConfirmationDate = x.ConfirmationDate,
                                              ContactEmail = x.ContactEmail,
                                              ContactName = x.ContactName,
                                              ContactPhone = x.ContactPhone,
                                              DetailsHtml = x.DetailsHtml,
                                              UrlName = x.UrlName,
                                              GMSListCode = x.GMSListCode,
                                              Active = x.Active
                                          }).AsQueryable().ToList<EventViewModel>();

                    return Queryablemodel;


                }
                catch (Exception ex)
                {
                   
                    return null;
                }


            }

        public List<EventViewModel> GetEventById(int id)
            {

                try
                {

                    var Queryablemodel = (from x in _context.Events
                                          join y in _context.Locations on x.LocationId equals y.Id
                                          join z in _context.EventTypes on x.EventTypeId equals z.Id
                                          where (x.Id == id)
                                          select new

                                          EventViewModel
                                          {
                                              Id = x.Id,
                                              Name = x.Name,
                                              LocationName = y.Name,
                                              EventTypeName = z.Name,
                                              StartDate = x.StartDate,
                                              EndDate = x.EndDate,
                                              MaxRegistrants = x.MaxRegistrants,
                                              RegistrationStartDate = x.RegistrationStartDate,
                                              RegistrationEndDate = x.RegistrationEndDate,
                                              IsConcurrentSessionAllowed = x.IsConcurrentSessionAllowed,
                                              MaxGuestsPerAttendee = x.MaxGuestsPerAttendee,
                                              DefaultCheckInDate = x.DefaultCheckInDate,
                                              DefaultCheckOutDate = x.DefaultCheckOutDate,
                                              EligibleGroup = x.EligibleGroup,
                                              EventTypeId = x.EventTypeId,
                                              LocationId = x.LocationId,
                                              ConfirmationDate = x.ConfirmationDate,
                                              ContactEmail = x.ContactEmail,
                                              ContactName = x.ContactName,
                                              ContactPhone = x.ContactPhone,
                                              DetailsHtml = x.DetailsHtml,
                                              UrlName = x.UrlName,
                                              GMSListCode = x.GMSListCode,
                                              Active = x.Active
                                          }).AsQueryable().ToList<EventViewModel>();


                    return Queryablemodel;
                }
                catch (Exception ex)
                {
                    
                    return null;
                }
            }
        public List<LocationViewModel> GetAllLocations()
            {
                try
                {
                    var Queryablemodel = (from x in _context.Locations
                                          select new
                                          LocationViewModel
                                          {
                                              Id = x.Id,
                                              Name = x.Name,
                                              Address = x.Address,
                                              City = x.City,
                                              CountryCode = x.CountryCode,
                                              State = x.State,
                                              PostalCode = x.PostalCode
                                          }).AsQueryable().ToList<LocationViewModel>();

                    return Queryablemodel;


                }
                catch (Exception ex)
                {
                   
                    return null;
                }
            }
        public List<LocationViewModel> GetLocationById(int id)
            {
                try
                {

                    var Queryablemodel = (from x in _context.Locations
                                          where (x.Id == id)
                                          select new

                                          LocationViewModel
                                          {
                                              Id = x.Id,
                                              Name = x.Name
                                          }).AsQueryable().ToList<LocationViewModel>();


                    return Queryablemodel;
                }
                catch (Exception ex)
                {
                    
                    return null;
                }
            }
        public List<EventTypeViewModel> GetAllEventTypes()
            {
                try
                {

                    var Queryablemodel = (from x in _context.EventTypes
                                          select new

                                          EventTypeViewModel
                                          {
                                              Id = x.Id,
                                              Name = x.Name,
                                              AdminRoles = x.AdminRoles,
                                              Image = x.Image
                                          }).AsQueryable().ToList<EventTypeViewModel>();


                    return Queryablemodel;
                }
                catch (Exception ex)
                {
                    
                    return null;
                }


            }
        public List<RegistrationProcessViewModel> GetRegistrationProcessById(int eventId)
            {

                try
                {

                    var Queryablemodel = (from x in _context.RegistrationProcesses
                                          orderby x.ScreenOrder ascending
                                          join y in _context.Events on x.EventId equals y.Id
                                          join w in _context.RegistrationScreens on x.RegistrationScreenId equals w.Id
                                          where (y.Id == eventId)
                                          select new
                                          RegistrationProcessViewModel
                                          {
                                              ScreenName = w.Name,
                                              Id = x.Id,
                                              ScreenOrder = x.ScreenOrder,
                                              RequiredScreen = w.RequiredScreen,
                                              RegistrationScreenId = x.RegistrationScreenId,
                                              TemplateUrl = w.TemplateUrl

                                          }).AsQueryable().ToList<RegistrationProcessViewModel>();
                    return Queryablemodel;
                }
                catch (Exception ex)
                {
                    
                    return null;
                }
            }
        public List<RegistrationScreensViewModel> GetRegistrationScreensAll()
            {

                try
                {

                    var Queryablemodel = (from x in _context.RegistrationScreens

                                          orderby x.DefaultOrder
                                          where (x.Active == true)
                                          select new
                                          RegistrationScreensViewModel
                                          {
                                              Id = x.Id,
                                              Name = x.Name,
                                              DefaultOrder = x.DefaultOrder
                                          }).AsQueryable().ToList<RegistrationScreensViewModel>();


                    return Queryablemodel;
                }
                catch (Exception ex)
                {
                   
                    return null;
                }
            }
        public List<RegistrationQuestionTypesViewModel> GetRegistrationQuestionTypes()
            {

                try
                {

                    var Queryablemodel = (from x in _context.RegistrationQuestionTypes
                                          orderby x.Name ascending
                                          select new
                                          RegistrationQuestionTypesViewModel
                                          {
                                              Id = x.Id,
                                              Name = x.Name
                                          }).AsQueryable().ToList<RegistrationQuestionTypesViewModel>();


                    return Queryablemodel;
                }
                catch (Exception ex)
                {
                    
                    return null;
                }
            }
        public List<RegistrationScreenQuestionViewModel> GetRegistrationScreenQuestionsByEventId(int eventId, int screenId, int attendeeId)
            {
            List<RegistrationScreenQuestionViewModel> questions = new List<RegistrationScreenQuestionViewModel>();

                if (screenId ==0)
                    {

                    questions =
                        (from rp in _context.RegistrationProcesses
                         join rs in _context.RegistrationScreens on rp.RegistrationScreenId equals rs.Id
                         join x in _context.RegistrationScreenQuestions on rs.Id equals x.RegistrationScreenId
                         join rpsq in _context.RegistrationProcessScreenQuestions on x.Id equals rpsq.RegistrationScreenQuestionId
                         join v in _context.RegistrationQuestionTypes on x.RegistrationQuestionTypeId equals v.Id
                         
                         where (rp.EventId == eventId )
                        
                         select new
                                     RegistrationScreenQuestionViewModel
                         {
                             Id = x.Id,
                             RegistrationQuestionTypeName = v.Name,
                             RegistrationQuestionTypeId = v.Id,
                             ConditionalQuestionId = x.ConditionalQuestionId,
                             RegistrationScreenId = x.RegistrationScreenId,
                             RegistrationScreenName = rs.Name,
                             QuestionDescription = x.QuestionDescription,
                             RequiredText = x.RequiredText,
                             SelectOptions = x.SelectOptions,
                             SelectOptionsDefault = x.SelectOptionsDefault,
                             QuestionVerbiage = x.QuestionVerbiage,
                             ReportDataName = x.ReportDataName,
                             HelpText = x.HelpText,
                             RequiredQuestion = x.RequiredQuestion,
                             RegistrationConditionalQuestionName = null,
                             Answer = "",
                             CMDBSource = x.ExternalSource,
                             RegistrationProcessScreenQuestionId = rpsq.Id,
                             SystemGenerated = x.SystemGenerated

                         }).AsQueryable().ToList<RegistrationScreenQuestionViewModel>();
            }
                else
                    {
                        questions =
                            (from y in _context.RegistrationProcesses
                             where (y.RegistrationScreenId == screenId)
                             join z in _context.RegistrationProcessScreenQuestions on y.Id equals z.RegistrationProcessId
                             join x in _context.RegistrationScreenQuestions on z.RegistrationScreenQuestionId equals x.Id
                             join v in _context.RegistrationQuestionTypes on x.RegistrationQuestionTypeId equals v.Id
                             where (y.EventId == eventId && y.RegistrationScreenId == screenId)
                             orderby z.DisplayOrder
                             select new
                                         RegistrationScreenQuestionViewModel
                             {
                                 Id = x.Id,
                                 RegistrationQuestionTypeName = v.Name,
                                 RegistrationQuestionTypeId = v.Id,
                                 ConditionalQuestionId = x.ConditionalQuestionId,
                                 RegistrationScreenId = x.RegistrationScreenId,
                                 QuestionDescription = x.QuestionDescription,
                                 RequiredText = x.RequiredText,
                                 SelectOptions = x.SelectOptions,
                                 SelectOptionsDefault = x.SelectOptionsDefault,
                                 QuestionVerbiage = x.QuestionVerbiage,
                                 ReportDataName = x.ReportDataName,
                                 HelpText = x.HelpText,
                                 RequiredQuestion = x.RequiredQuestion,
                                 RegistrationConditionalQuestionName = null,
                                 Answer = "",
                                 CMDBSource = x.ExternalSource,
                                 RegistrationProcessScreenQuestionId = z.Id

                             }).AsQueryable().ToList<RegistrationScreenQuestionViewModel>();
            }
               
                    foreach (RegistrationScreenQuestionViewModel question in questions)
                        {
                            RegistrationScreenQuestionDataViewModel vm  = GetRegistrationQuestionScreenData(attendeeId, eventId, question.RegistrationProcessScreenQuestionId);
                            if (vm != null)
                {
                    question.Answer = vm.Value;
                }
               
                        }


            return questions;
            }
        public List<RegistrationScreenQuestionViewModel> GetRegistrationScreenQuestions(int id)
            {

                try
                {

                    var Queryablemodel = (from x in _context.RegistrationScreenQuestions
                                          join v in _context.RegistrationScreens on x.RegistrationScreenId equals v.Id
                                          where (x.RegistrationScreenId == id)
                                          orderby x.QuestionVerbiage
                                          join y in _context.RegistrationQuestionTypes on x.RegistrationQuestionTypeId equals y.Id
                                          join zz in _context.RegistrationScreenQuestions on x.ConditionalQuestionId equals zz.Id into list
                                          from result in list.DefaultIfEmpty()

                                          select new
                                          RegistrationScreenQuestionViewModel
                                          {
                                              Id = x.Id,
                                              RegistrationQuestionTypeName = y.Name,
                                              RegistrationScreenName = v.Name,
                                              RegistrationQuestionTypeId = x.RegistrationQuestionTypeId,
                                              ConditionalQuestionId = x.ConditionalQuestionId,
                                              RegistrationScreenId = x.RegistrationScreenId,
                                              QuestionDescription = x.QuestionDescription,
                                              RequiredText = x.RequiredText,
                                              SelectOptions = x.SelectOptions,
                                              QuestionVerbiage = x.QuestionVerbiage,
                                              ReportDataName = x.ReportDataName,
                                              HelpText = x.HelpText,
                                              RequiredQuestion = x.RequiredQuestion,
                                              RegistrationConditionalQuestionName = result


                                          }).AsQueryable().ToList<RegistrationScreenQuestionViewModel>();


                    return Queryablemodel;
                }
                catch (Exception ex)
                {
                    
                    return null;
                }
            }
        public List<RegistrationScreenQuestionViewModel> GetAllRegistrationScreenQuestions()
            {

                try
                {

                    var Queryablemodel = (from x in _context.RegistrationScreenQuestions
                                          join v in _context.RegistrationScreens on x.RegistrationScreenId equals v.Id
                                          orderby x.QuestionVerbiage
                                          join y in _context.RegistrationQuestionTypes on x.RegistrationQuestionTypeId equals y.Id
                                          join zz in _context.RegistrationScreenQuestions on x.ConditionalQuestionId equals zz.Id into list
                                          from result in list.DefaultIfEmpty()
                                          select new
                                          RegistrationScreenQuestionViewModel
                                          {
                                              Id = x.Id,
                                              RegistrationQuestionTypeName = y.Name,
                                              RegistrationScreenName = v.Name,
                                              RegistrationQuestionTypeId = x.RegistrationQuestionTypeId,
                                              ConditionalQuestionId = x.ConditionalQuestionId,
                                              RegistrationScreenId = x.RegistrationScreenId,
                                              QuestionDescription = x.QuestionDescription,
                                              RequiredText = x.RequiredText,
                                              SelectOptions = x.SelectOptions,
                                              QuestionVerbiage = x.QuestionVerbiage,
                                              ReportDataName = x.ReportDataName,
                                              HelpText = x.HelpText,
                                              RequiredQuestion = x.RequiredQuestion,
                                              RegistrationConditionalQuestionName = result,
                                              Active = x.Active


                                          }).AsQueryable().ToList<RegistrationScreenQuestionViewModel>();


                    return Queryablemodel;
                }
                catch (Exception ex)
                {
                   
                    return null;
                }
            }
        public List<RegistrationProcessScreenQuestionsViewModel> GetRegistrationProcessScreenQuestions(int id)
            {


                try
                {
                    var Queryablemodel = (from w in _context.RegistrationProcessScreenQuestions
                                          orderby w.DisplayOrder
                                          join x in _context.RegistrationProcesses on w.RegistrationProcessId equals x.Id
                                          join y in _context.RegistrationScreenQuestions on w.RegistrationScreenQuestionId equals y.Id
                                          where (x.RegistrationScreenId == id)
                                          join z in _context.RegistrationScreenQuestions on y.ConditionalQuestionId equals z.Id into list
                                          from z in list.DefaultIfEmpty()
                                          select new
                                          RegistrationProcessScreenQuestionsViewModel
                                          {
                                              Id = w.Id,
                                              QuestionVerbiage = y.QuestionVerbiage,
                                              SelectOptions = y.SelectOptions,
                                              DisplayOrder = w.DisplayOrder,
                                              RegistrationProcessId = w.RegistrationProcessId,
                                              RegistrationScreenQuestionId = w.RegistrationScreenQuestionId,
                                              RegistrationConditionalQuestionName = z

                                          }).OrderBy(x=> x.DisplayOrder).AsQueryable().ToList<RegistrationProcessScreenQuestionsViewModel>();


                    return Queryablemodel;
                }
                catch (Exception ex)
                {
                    
                    return null;
                }
            }
        public RegistrationScreen GetRegistrationScreenById(int id)
            {


                try
                {


                    var Queryablemodel = (from x in _context.RegistrationScreens
                                          where (x.Id == id)
                                          select new
                                          RegistrationScreen
                                          {
                                              Id = x.Id,
                                              Active = x.Active,
                                              DefaultOrder = x.DefaultOrder,
                                              Description = x.Description,
                                              Name = x.Name,
                                              RequiredScreen = x.RequiredScreen,
                                              TemplateUrl = x.TemplateUrl
                                          }).AsQueryable().First<RegistrationScreen>();


                    return Queryablemodel;
                }
                catch (Exception ex)
                {
                    
                    return null;
                }
            }
        public RegistrationProcessScreenQuestionsViewModel GetRegistrationProcessScreenQuestionById(int id)
            {


                try
                {
                    var Queryablemodel = (from x in _context.RegistrationProcessScreenQuestions
                                          where (x.Id == id)
                                          select new
                                          RegistrationProcessScreenQuestionsViewModel
                                          {
                                              Id = x.Id,
                                              RegistrationScreenQuestionId = x.RegistrationScreenQuestionId,
                                              DisplayOrder = x.DisplayOrder
                                          }).AsQueryable().First<RegistrationProcessScreenQuestionsViewModel>();


                    return Queryablemodel;
                }
                catch (Exception ex)
                {
                    
                    return null;
                }
            }
        public List<RegistrationProcessViewModel> GetRegistrationProcessByIdforDelete(int id)
            {
                try
                {
                    var registrationProcess = (from x in _context.RegistrationProcesses
                                          where (x.Id == id)
                                          select new
                                          RegistrationProcessViewModel
                                          {
                                              Id = x.Id,
                                              EventId = x.EventId,
                                              RegistrationScreenId = x.RegistrationScreenId,
                                              ScreenOrder = x.ScreenOrder
                                          }).ToList<RegistrationProcessViewModel>();


                    return registrationProcess;
                }
                catch (Exception ex)
                {
                    
                    return null;
                }
            }
            public RegistrationScreenQuestionViewModel GetRegistrationQuestionById(int id)
            {
                try
                {
                    var Queryablemodel = (from x in _context.RegistrationScreenQuestions
                                          where (x.Id == id)
                                          select new
                                          RegistrationScreenQuestionViewModel
                                          {
                                              Id = x.Id,
                                              RegistrationQuestionTypeId = x.RegistrationQuestionTypeId,
                                              ConditionalQuestionId = x.ConditionalQuestionId,
                                              RegistrationScreenId = x.RegistrationScreenId,
                                              DefaultQuestion = x.DefaultQuestion,
                                              QuestionDescription = x.QuestionDescription,
                                              QuestionVerbiage = x.QuestionVerbiage,
                                              ReportDataName = x.ReportDataName,
                                              HelpText = x.HelpText,
                                              ConditionalQuestionResponse = x.ConditionalQuestionResponse,
                                              RequiredQuestion = x.RequiredQuestion,
                                              RequiredText = x.RequiredText,
                                              SelectOptions = x.SelectOptions,
                                              SelectOptionsDefault = x.SelectOptionsDefault,
                                              Active = x.Active,
                                              ExternalSource = x.ExternalSource,
                                              SystemGenerated = x.SystemGenerated

                                          }).AsQueryable().First<RegistrationScreenQuestionViewModel>();


                    return Queryablemodel;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            public UserDetails GetUserDetails(int id)
            {
                try
                {
                    var Queryablemodel = (from x in _context.UserDetails
                                          where (x.Id == id)
                                          select new
                                          UserDetails
                                          {
                                              Id = x.Id,
                                              FirstName = x.FirstName,
                                              LastName = x.LastName,
                                              ALPANumber = x.ALPANumber,
                                              Email = x.Email,
                                              Phone = x.Phone,
                                              UserId = x.UserId,
                                              UserTypeId = x.UserTypeId,
                                              Active = x.Active,
                                              Verified = x.Verified

                                          }).AsQueryable().First<UserDetails>();


                    return Queryablemodel;
                }
                catch (Exception)
                { 
                    return null;
                }
            }

        public EventManagerSessionViewModel GetEventManagerSessionBySessionGuid(string sessionGuid)
        {
            try
            {
                var Queryablemodel = (from x in _context.EventManagerSessions
                                      where (x.SessionGuid == sessionGuid)
                                      select new
                                      EventManagerSessionViewModel
                                      {
                                          Id = x.Id,
                                          UserName = x.UserName,
                                          AttendeeId = x.AttendeeId,
                                          AttendeeUserName = x.AttendeeUserName,
                                          EventId = x.EventId,
                                          SessionGuid = x.SessionGuid,
                                          UserId = x.UserId,
                                          Login = x.Login
                                  
                                     }).AsQueryable().First<EventManagerSessionViewModel>();
                return Queryablemodel;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion Get Meth
        #region Add Methods

        public void AddGuests(List<Guest> guests)
        {
            DeleteGuestsByAttendeeId(guests);

            try
            {
              
                foreach (Guest g in guests)
                {
                    AddGuest(g);
                }
            }

            catch (Exception)
            {

            }
        }
       
        public Guest AddGuest(Guest newGuest)
        {
            try
            {
                if (newGuest.Id > 0)
                    _context.Entry(newGuest).State = System.Data.Entity.EntityState.Modified;
                else
                    newGuest = _context.Guests.Add(newGuest);
                _context.SaveChanges();
                return newGuest;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RegistrationScreenQuestionData AddRegistrationQuestionScreenData(RegistrationScreenQuestionData newRegistrationScreenQuestionData)
        {
            try
            {
                newRegistrationScreenQuestionData.DateAnswered = DateTime.Now;
                if (newRegistrationScreenQuestionData.Id > 0)
                    _context.Entry(newRegistrationScreenQuestionData).State = System.Data.Entity.EntityState.Modified;
                else
                    newRegistrationScreenQuestionData = _context.RegistrationScreenQuestionData.Add(newRegistrationScreenQuestionData);
                _context.SaveChanges();
                return newRegistrationScreenQuestionData;
            }
            catch (Exception ex)
            {
                return null;
            }

         
        }

        public EventManagerSession AddEventManagerSession(EventManagerSession newEventManagerSession)
        {
            try
            {
                if (newEventManagerSession.Id > 0)
                    _context.Entry(newEventManagerSession).State = System.Data.Entity.EntityState.Modified;
                else
                    newEventManagerSession = _context.EventManagerSessions.Add(newEventManagerSession);
                _context.SaveChanges();
                return newEventManagerSession;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Attendee AddAttendee(Attendee newAttendee)
        {
            List<Guest> guests = newAttendee.Guests;

            try
            {
                if (newAttendee.Id > 0)
                    _context.Entry(newAttendee).State = System.Data.Entity.EntityState.Modified;
                else
                {
                    newAttendee.RegisterStarted = DateTime.Now;
                    newAttendee = _context.Attendees.Add(newAttendee);
                }
                    
                _context.SaveChanges();
                newAttendee.Guests = guests;
               //if there are guests add them
                if (newAttendee.Guests!= null)
                {
                    if (newAttendee.Guests.Count() > 0)
                        AddGuests(newAttendee.Guests.ToList());
                }

                return newAttendee;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void AddUser(ApplicationUser appUser)
            {
                try
                {
                if (appUser.Id > 0)
                {
                    _context.Users.Remove(appUser);
                    _context.Users.Add(appUser);
                }
                    
                    

                //need to add the default screen too

                else
                    _context.Users.Add(appUser);
                }
                catch (Exception ex)
                {
                    string test = ex.Message;
                }

            _context.SaveChanges();

            }
        public void AddEvent(Event newEvent)
        {
            try
            {
                if (newEvent.Id > 0)
                    _context.Entry(newEvent).State = System.Data.Entity.EntityState.Modified;
                else
                    _context.Entry(newEvent).State = System.Data.Entity.EntityState.Added;
               
                _context.SaveChanges();
            }
            
            catch (Exception)
            {
                
            }
        }
        public EventType AddEventType(EventType newEventType)
        {
            try
            {
                if (newEventType.Id > 0)
                    _context.Entry(newEventType).State = System.Data.Entity.EntityState.Modified;
                else
                   newEventType =  _context.EventTypes.Add(newEventType);
                _context.SaveChanges();
                return newEventType;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Location AddLocation(Location newLocation)
        {
            try
            {
                if (newLocation.Id > 0)
                    _context.Entry(newLocation).State = System.Data.Entity.EntityState.Modified;

                else
                    newLocation =  _context.Locations.Add(newLocation);

                _context.SaveChanges();
                return newLocation;
                
            }
            catch (Exception)
            {
                return null;
            }
        }
        public RegistrationProcess AddRegistrationProcess(RegistrationProcess newRegistrationProcess)
        {
            try
            {
                if (newRegistrationProcess.Id > 0)
                    _context.Entry(newRegistrationProcess).State = System.Data.Entity.EntityState.Modified;
                else
                    newRegistrationProcess = _context.RegistrationProcesses.Add(newRegistrationProcess);

                _context.SaveChanges();
                return newRegistrationProcess;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void AddRegistrationScreenQuestion(RegistrationScreenQuestion newRegistrationScreenQuestion)
        {
            try
            {
                if (newRegistrationScreenQuestion.Id > 0)
                    _context.Entry(newRegistrationScreenQuestion).State = System.Data.Entity.EntityState.Modified;
                else
                    _context.RegistrationScreenQuestions.Add(newRegistrationScreenQuestion);
                _context.SaveChanges();
            }
            catch (Exception)
            {   
            }
        }
        public void AddRegistrationProcessScreenQuestion(RegistrationProcessScreenQuestion newRegistrationProcessScreenQuestion)
        {
            try
            {
                if (newRegistrationProcessScreenQuestion.Id > 0)
                    _context.Entry(newRegistrationProcessScreenQuestion).State = System.Data.Entity.EntityState.Modified;
                else
                    _context.RegistrationProcessScreenQuestions.Add(newRegistrationProcessScreenQuestion);

                _context.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        #endregion Add Methods

        #region Delete Methods

        public void DeleteGuest(Guest id)
        {

            try
            {
                _context.Guests.Attach(id);
                _context.Guests.Remove(id);
                _context.SaveChanges();
            }

            catch (Exception ex)
            {
                var test = ex.Message;
            }
        }

        public void DeleteGuestsByAttendeeId(List<Guest> guests)
        {
            int attendeeId = guests[0].AttendeeId;

            List<GuestViewModel> process = GetGuestsByAttendeeId(attendeeId);
            if (process.Count == 0)
                return;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GuestViewModel, Guest>());
            var mapper = config.CreateMapper();

            Guest newRegistrationProcess = mapper.Map<Guest>(process);
            try
            {
                for (int i = 0; i < process.Count; i++)
                {
                    newRegistrationProcess = mapper.Map<Guest>(process[i]);
                    DeleteGuest(newRegistrationProcess);
                }
                
            }

            catch (Exception ex)
            {
                var testc = ex.Message;
            }
        }
        public void DeleteRegistrationScreenQuestion(RegistrationProcessScreenQuestion id)
        {
          
            try
            {
                _context.RegistrationProcessScreenQuestions.Attach(id);
                _context.RegistrationProcessScreenQuestions.Remove(id);
                _context.SaveChanges();
            }

            catch (Exception)
            {
                
            }
        }
        public void DeleteRegistrationScreenQuestionData(RegistrationScreenQuestionData id)
        {
          
            try
            {
                _context.RegistrationScreenQuestionData.Attach(id);
                _context.RegistrationScreenQuestionData.Remove(id);
                _context.SaveChanges();
            }

            catch (Exception)
            {
                
            }


        }
       
        public void DeleteRegistrationProcess(int id)
        {
            List<RegistrationProcessViewModel> process = GetRegistrationProcessByIdforDelete(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<RegistrationProcessViewModel, RegistrationProcess>());
            var mapper = config.CreateMapper();

            RegistrationProcess newRegistrationProcess = mapper.Map<RegistrationProcess>(process[0]);

            try
            {
                _context.RegistrationProcesses.Attach(newRegistrationProcess);
                _context.RegistrationProcesses.Remove(newRegistrationProcess);
                _context.SaveChanges();
            }

            catch (Exception ex)
            {
               
            }


        }

        public void DeleteRegistrationScreen(int id)
        {
            RegistrationScreen registrationScreen = GetRegistrationScreenById(id);

            try
            {
                _context.RegistrationScreens.Attach(registrationScreen);
                _context.RegistrationScreens.Remove(registrationScreen);
                _context.SaveChanges();
            }

            catch (Exception ex)
            {

            }


        }
        public void DeleteRegistrationProcessScreenQuestion(int id)
        {
            RegistrationProcessScreenQuestionsViewModel process = GetRegistrationProcessScreenQuestionById(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<RegistrationProcessScreenQuestionsViewModel, RegistrationProcessScreenQuestion>());
            var mapper = config.CreateMapper();

            RegistrationProcessScreenQuestion newRegistrationProcess = mapper.Map<RegistrationProcessScreenQuestion>(process);
            try
            {
                _context.RegistrationProcessScreenQuestions.Attach(newRegistrationProcess);
                _context.RegistrationProcessScreenQuestions.Remove(newRegistrationProcess);
                _context.SaveChanges();
            }

            catch (Exception ex)
            {

            }


        }

        #endregion Delete Methods

        #region Report Stored Procs

        public List<rptAttendeeBadgeViewModel> GetrptAttendeeBadge(int id)
        {
            List<rptAttendeeBadgeViewModel> list = new List<rptAttendeeBadgeViewModel>();
            rptAttendeeBadgeViewModel item = new rptAttendeeBadgeViewModel();
         //   SqlConnection connection = new SqlConnection("Data Source=CMDBVDB;Initial Catalog=ALPAEvents;User ID=ALPAEvents;Password=Aevt**gen;MultipleActiveResultSets=true");
            SqlConnection connection = new SqlConnection("Data Source = LT00052223\\SQLEXPRESS; Initial Catalog = EventManager; Integrated Security = True");

            SqlCommand proc = new SqlCommand("sp_rptAttendeeBadge", connection);
            connection.Open();

            proc.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlparams = new SqlParameter("id", 16);

            proc.Parameters.Add(sqlparams);


            var reader = proc.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    item = new rptAttendeeBadgeViewModel();
                    item.id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1))
                    {
                        item.FIRSTNAME = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        item.LASTNAME = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        item.BADGENAME = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        item.ORGANIZATION = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        item.BADGEPOSITION = reader.GetString(5);
                    }

                    if (!reader.IsDBNull(6))
                    {
                        item.COUNCILNUMBER = reader.GetString(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        item.COUNCILLOCATION = reader.GetString(7);
                    }
                    if (!reader.IsDBNull(8))
                    {
                        item.BADGEGENERATED = reader.GetBoolean(8);
                    }


                    list.Add(item);

                }
            }
            else
            {
                return null;
            }

            connection.Close();

            return list;
        }
        #endregion Report Stored Procs
    

        public bool SaveAll()
        {
            try
            {
                return (_context.SaveChanges() > 0); //return number of rows changed
            }
            catch (Exception ex)
            {
               
                return false;
            }

        }


        //dashboard

        public List<DashboardCurrentRegistrationsViewModel> GetDashboardCurrentRegistrations(int Eventid)
        {

         
            try
            {
               var  Queryablemodel = (from x in _context.RegistrationProcessScreenQuestions
                                      join y in _context.RegistrationProcesses on x.RegistrationProcessId equals y.Id
                                      join z in _context.RegistrationScreenQuestionData on x.Id equals z.RegistrationProcessScreenQuestionId
                                      join a in _context.RegistrationScreenQuestions on x.RegistrationScreenQuestionId equals a.Id
                                      join b in _context.Events on z.EventId equals b.Id
                                      join c in _context.Attendees on z.AttendeeId equals c.Id
                                      join d in _context.AttendeeTypes on c.AttendeeTypeId equals d.Id
                                      join e in _context.AirlineCodes on c.Organization equals e.Code

                                      select new DashboardCurrentRegistrationsViewModel
                                      {
                                          Id = z.AttendeeId,
                                          EventId = c.EventId,
                                          ALPANumber = c.ALPANumber,
                                          FirstName = c.FirstName,
                                          LastName = c.LastName,
                                          Organization = e.Name,
                                          RegisterCompleteDate = c.RegisterCompleteDate,
                                          RegisterStarted = c.RegisterStarted,
                                          Value = z.Value,
                                          ProxyUser = c.ProxyUser,
                                          ReportDataName = a.ReportDataName,
                                          AttendeeTypeId = c.AttendeeTypeId,
                                          AttendeeTypeName = d.Name
                                      }).Where(d => d.EventId == Eventid).Where(e => e.ReportDataName == "Attending").AsQueryable().ToList<DashboardCurrentRegistrationsViewModel>();
                return Queryablemodel.ToList();

            }catch(Exception ex)
            {
                var test = ex.Message;
                return null;

            }
              
        }

        public List<DashboardCurrentRegistrationsViewModel> GetDashboardNotRegistered(int EventId)
        {
            var query =
                from x in _context.Member
                join a in _context.gmsMember on x.ALPA_ID equals a.MemberId
                join y in _context.gmsList on a.ListId equals y.ListId
                join z in _context.Events on EventId equals z.Id
                where !_context.Attendees.Any(p => p.ALPANumber == x.ALPA_ID)
                where z.GMSListCode == y.ListCode
                select new DashboardCurrentRegistrationsViewModel
                {

                    EventId = EventId,
                    ALPANumber = x.ALPA_ID,
                    FirstName = x.FRST_NAME,
                    LastName = x.LST_NAME,
                    Organization = x.MEC_CD,
                    ListId = y.ListId,
                    Memo = a.Memo

                };



         
            return query.ToList<DashboardCurrentRegistrationsViewModel>();
        }


        public List<DashboardCurrentRegistrationsViewModel> GetDashboardNotAttending(int EventId)
        {
            var query =
                from x in _context.Attendees
                join y in _context.RegistrationScreenQuestionData on x.Id equals y.AttendeeId
                join z in _context.Member on x.ALPANumber equals z.ALPA_ID
                where y.EventId == EventId
                where y.RegistrationProcessScreenQuestionId == 1
                where y.Value == "NO"
                select new DashboardCurrentRegistrationsViewModel
                {

                    EventId = EventId,
                    ALPANumber = z.ALPA_ID,
                    FirstName = z.FRST_NAME,
                    LastName = z.LST_NAME,
                    Organization = z.MEC_CD,
                    Value = y.Value

                };


            return query.ToList<DashboardCurrentRegistrationsViewModel>(); 
        }

    }
}

