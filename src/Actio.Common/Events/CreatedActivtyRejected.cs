namespace Actio.Common.Events
{
    public class CreatedActivtyRejected : IRejectedEvent
    {
        public string Reason { get; }

        public int Code { get; }

        protected CreatedActivtyRejected()
        {
        }

        public CreatedActivtyRejected(string reason, int code)
        {
            Reason = reason;
            Code = code;
        }
    }
}