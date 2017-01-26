namespace EventManager.Core
{
    public class MemberCommunication
    {
        public string Number { get; set; }
        public string CategoryCode { get; set; }
        public string TypeCode { get; set; }
        public string Value { get; set; }
        public string Extension { get; set; }
        public string BadIndicator { get; set; }

        // References
        public virtual Member Member { get; set; }
    }

}
