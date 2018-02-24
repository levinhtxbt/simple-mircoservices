namespace Actio.Common.Events
{
    public class UserAuthenticated : IEvent
    {
        public string Email { get; set; }

        public string Token { get; set; }

        protected UserAuthenticated()
        {

        }

        public UserAuthenticated(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }
}