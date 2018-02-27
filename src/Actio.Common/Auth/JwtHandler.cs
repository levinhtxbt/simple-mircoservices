using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Actio.Common.Auth
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        private readonly JwtHeader _jwtHeader;

        private readonly JwtOptions _option;

        private readonly SecurityKey _issuerSigningKey;

        private readonly SigningCredentials _signingCredentials;

        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtHandler(IOptions<JwtOptions> options)
        {
            _option = options.Value;
            _issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_option.SecretKey));
            _signingCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256);
            _jwtHeader = new JwtHeader(_signingCredentials);
            _tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = _option.Issuer,
                IssuerSigningKey = _issuerSigningKey
            };

        }

        public JsonWebToken Create(Guid userId)
        {
            var utcNow = DateTime.UtcNow;
            var expires = utcNow.AddMinutes(_option.ExpiryMinutes);
            var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
            var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
            var now = (long)(new TimeSpan(utcNow.Ticks - centuryBegin.Ticks).TotalSeconds);
            var payload = new JwtPayload
            {
                { "sub", userId },
                { "iss", _option.Issuer },
                { "iat", now },
                { "exp", exp },
                { "unique_name", userId }
            };
            var jwt = new JwtSecurityToken(_jwtHeader, payload);
            var token = _jwtSecurityTokenHandler.WriteToken(jwt);

            return new JsonWebToken(token, exp);
        }
    }
}