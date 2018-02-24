namespace Actio.Common.Events
{
    public class CreateUserRejected : IRejectedEvent
    {
        public string Reason { get; }

        public string Code { get; }

        protected CreateUserRejected()
        {
        }

        public CreateUserRejected(string code, string reason)
        {
            Code = code;
            Reason = reason;
        }
    }
}