using System;

namespace EventManager.Core
{

    public class EventSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AttendeeTypeCount { get; set; }        
        public int AttendeeCount { get; set; }
        public int SessionCount { get; set; }
        public int HotelCount { get; set; }
       
        public int AttendeeType { get; set; }
        public int PreReqCount { get; set; }

        public string Image { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }


    }
}
