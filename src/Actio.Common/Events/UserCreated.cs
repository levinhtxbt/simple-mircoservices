namespace Actio.Common.Events
{
    public class UserCreated : IEvent
    {
        public string Email { get; }

        public string Username { get; }

        protected UserCreated()
        {

        }

        public UserCreated(string email, string username)
        {
            Email = email;
            Username = username;
        }
    }
}