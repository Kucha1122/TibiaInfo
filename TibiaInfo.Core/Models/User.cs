using System;
using System.Collections.Generic;
using TibiaInfo.Core.Exceptions;

namespace TibiaInfo.Core.Models
{
    public class User : Entity
    {
        private static List<string> _roles = new List<string>
        {
            "user", "admin"
        };

        public string Role { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        public byte[] PasswordHash { get; protected set; }
        public byte[] PasswordSalt { get; protected set; }
        public DateTime? CreatedAt { get; protected set; }

        public IList<TibiaCharacter> TibiaCharacters { get; set; }

        protected User()
        {

        }

        public User(Guid id, string role, string login, string password)
        {
            Id = id;
            SetRole(role);
            SetLogin(login);
            SetPassword(password);
        }

        public void SetLogin(string login)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(login))
                {
                    Login = login;
                }
            }
            catch (Exception e)
            {
                throw new NullOrWhiteSpaceException("Login cannot be empty!", e);
            }
        }

        public void SetRole(string role)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(role))
                {
                    role = role.ToLowerInvariant();
                    if(_roles.Contains(role))
                    {
                        Role = role;
                    }
                }
            }
            catch (Exception e)
            {
                throw new NullOrWhiteSpaceException("Role cannot be empty, or you trying set wrong role!", e);
            }
        }

        public void SetPassword(string password)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(password))
                {
                    Password = password;
                }
            }
            catch (Exception e)
            {
                throw new NullOrWhiteSpaceException("Password cannot be empty!", e);
            }
        }
    }
}