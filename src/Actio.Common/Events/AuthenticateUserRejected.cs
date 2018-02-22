namespace Actio.Common.Events
{
    public class AuthenticateUserRejected : IRejectedEvent
    {
        public string Reason { get; }

        public int Code { get; }

        public string Email { get; set; }

        protected AuthenticateUserRejected()
        {
        }

        public AuthenticateUserRejected(string reason, int code, string email) 
        {
            Reason = reason;
            Code = code;
            Email = email;
        }

    }
}