namespace Actio.Common.Events
{
    public class AuthenticateUserRejected : IRejectedEvent
    {
        public string Reason { get; }

        public string Code { get; }

        public string Email { get; set; }

        protected AuthenticateUserRejected()
        {
        }

        public AuthenticateUserRejected(string code, string reason, string email) 
        {
            Code = code;
            Reason = reason;
            Email = email;
        }

    }
}