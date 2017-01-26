using System;

namespace EventManager.Core
{

    public class RegistrationSummary
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public int RegistrationId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int AttendeeId { get; set; }
        public  string AttendeeType { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MemberNumber { get; set; }
        public string Organization { get; set; }
        public string Email { get; set; }


    }
}
