namespace Actio.Common.Events
{
    public class CreatedActivtyRejected : IRejectedEvent
    {
        public string Reason { get; }

        public string Code { get; }

        protected CreatedActivtyRejected()
        {
        }

        public CreatedActivtyRejected(string code, string reason)
        {
            Code = code;
            Reason = reason;
        }
    }
}