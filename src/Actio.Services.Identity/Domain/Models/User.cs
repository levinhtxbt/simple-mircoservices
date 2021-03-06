using System;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Domain.Services;

namespace Actio.Services.Identity.Domain.Models
{
    public class User
    {
        public Guid Id { get; protected set; }

        public string Email { get; protected set; }

        public string Name { get; protected set; }

        public string Password { get; protected set; }

        public string Salt { get; set; }

        public DateTime CreatedAt { get; set; }

        protected User()
        {

        }

        public User(string email, string name)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ActioException("empty_email",
                    "Email cannot be empty");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ActioException("empty_username",
                    "Name cannot be empty");
            }

            Id = Guid.NewGuid();
            Email = email;
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IEncryptor encryptor)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ActioException("empty_password",
                    "Password cannot be empty");
            }
            Salt = encryptor.GetSalt(Password);
            Password = encryptor.GetHash(password, Salt);
        }

        public bool VerifyPassword(string password, IEncryptor encryptor)
            => Password.Equals(encryptor.GetHash(password, Salt));
    }
}