namespace Actio.Common.Events
{
    public class AuthenticateUserRejected : IRejectedEvent
    {
        public string Reason { get; }

        public string Code { get; }


        protected AuthenticateUserRejected()
        {
        }

        public AuthenticateUserRejected(string code, string reason)
        {
            Code = code;
            Reason = reason;
        }
    }
}