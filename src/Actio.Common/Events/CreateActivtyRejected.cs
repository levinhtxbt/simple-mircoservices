namespace Actio.Common.Events
{
    public class CreateActivtyRejected : IRejectedEvent
    {
        public string Reason { get; }

        public string Code { get; }

        protected CreateActivtyRejected()
        {
        }

        public CreateActivtyRejected(string code, string reason)
        {
            Code = code;
            Reason = reason;
        }
    }
}