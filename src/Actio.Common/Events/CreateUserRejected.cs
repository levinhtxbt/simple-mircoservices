namespace Actio.Common.Events
{
    public class CreateUserRejected : IRejectedEvent
    {
        public string Reason { get; }

        public int Code { get; }

        protected CreateUserRejected()
        {
        }

        public CreateUserRejected(string reason, int code)
        {
            Reason = reason;
            Code = code;
        }
    }
}