using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.ViewModels;

namespace EventManager.Core
{
    public interface IEventManagerRepository
    {
        List<AttendeeRegistrationViewModel> GetReportDataByAttendeeEventId(int AttendeeId, int EventId);
        List<GuestViewModel> GetGuestsByAttendeeId(int id);
        List<AttendeeTypeViewModel> GetAttendeeTypes();
        List<AttendeeViewModel> GetAttendeeByAlpaId(string id, int eventId);
        RegistrationScreenQuestionDataViewModel GetRegistrationQuestionScreenData(int attendeeId, int eventId, int registrationProcessScreenQuestionId);
        List<RegistrationScreenQuestionDataViewModel> GetRegistrationScreenQuestionData(int attendeeId, int eventId);
        List<RegistrationQuestionExternalMappingViewModel> GetRegistrationQuestionExternalMappings();
        List<AttendeeViewModel> GetAttendeeById(int id);
        RegistrationScreen GetRegistrationScreenById(int id);
        List<RegistrationProcessViewModel> GetRegistrationProcessByIdforDelete(int id);
        List<RegistrationScreenQuestionViewModel> GetRegistrationScreenQuestionsByEventId(int eventId, int screenId, int attendeeid);
        List<RegistrationScreenQuestionViewModel> GetAllRegistrationScreenQuestions();
        RegistrationScreenQuestionViewModel GetRegistrationQuestionById(int id);
        List<GMSMemberDataViewModel> GetMemberDataUsingAlpaId(string alpaId, int eventId);
        List<EventViewModel> GetAllEvents();
        List<EventViewModel> GetAllActiveEvents();
        List<LocationViewModel> GetAllLocations();
        List<LocationViewModel> GetLocationById(int id);
        List<EventTypeViewModel> GetAllEventTypes();
        EventManagerSessionViewModel GetEventManagerSessionBySessionGuid(string sessionGuid);
        bool SaveAll();

        Guest AddGuest(Guest newGuest);
        RegistrationScreenQuestionData AddRegistrationQuestionScreenData(RegistrationScreenQuestionData newRegistrationScreenQuestionData);
        Attendee AddAttendee(Attendee newAttendee);
        EventManagerSession AddEventManagerSession(EventManagerSession newEventManagerSession);
        void AddEvent(Event newEvent);
        Location AddLocation(Location newLocation);
        EventType AddEventType(EventType newEventType);
        List<EventViewModel> GetEventById(int id);
        List<RegistrationProcessViewModel> GetRegistrationProcessById(int id);
        RegistrationProcess AddRegistrationProcess(RegistrationProcess newRegistrationProcess);
        List<RegistrationQuestionTypesViewModel> GetRegistrationQuestionTypes();
        List<RegistrationScreensViewModel> GetRegistrationScreensAll();
        List<rptAttendeeBadgeViewModel> GetrptAttendeeBadge(int id);
        List<RegistrationScreenQuestionViewModel> GetRegistrationScreenQuestions(int id);
        void AddRegistrationScreenQuestion(RegistrationScreenQuestion newRegistrationScreenQuestion);
        void AddRegistrationProcessScreenQuestion(RegistrationProcessScreenQuestion newRegistrationProcessScreenQuestion);
        List<RegistrationProcessScreenQuestionsViewModel> GetRegistrationProcessScreenQuestions(int id);
        void DeleteRegistrationScreen(int id);
        void DeleteRegistrationProcess(int id);
        void DeleteRegistrationProcessScreenQuestion(int id);
        void DeleteGuest(Guest id);
        void DeleteRegistrationScreenQuestionData(RegistrationScreenQuestionData id);
        //UserDetails GetUserDetails(int id);
        List<DashboardCurrentRegistrationsViewModel> GetDashboardCurrentRegistrations(int Eventid);
        List<DashboardCurrentRegistrationsViewModel> GetDashboardNotRegistered(int EventId);

        List<DashboardCurrentRegistrationsViewModel> GetDashboardNotAttending(int EventId);
    }
}
