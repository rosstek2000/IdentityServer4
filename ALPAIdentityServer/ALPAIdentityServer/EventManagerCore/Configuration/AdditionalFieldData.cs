namespace EventManager.Core
{
    public class AdditionalFieldData
    {
        public int Id { get; set; }
        public int? RegistrationId { get; set; }
        public int? AttendeeId { get; set; }
        public int? AccommodationId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        // References
       // public virtual Registration.Registration Registration { get; set; }
        public virtual Attendee Attendee { get; set; }
        public virtual Accommodation Accommodation { get; set; }
    }

}
