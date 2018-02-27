namespace Actio.Common.Auth
{
    public class JsonWebToken
    {
        public JsonWebToken()
        {
        }

        public JsonWebToken(string token, long expires)
        {
            this.Token = token;
            this.Expires = expires;

        }
        public string Token { get; set; }

        public long Expires { get; set; }


    }
}